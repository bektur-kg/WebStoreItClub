using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebStore.Model.ModelDTO;
using WebStore.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebStore.Controllers
{
    /// <summary>
    ///     Контроллер управляющий продуктами
    /// </summary>
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        ///     Инициализирует контекст базы данных <see cref="ApplicationDbContext"/>
        /// </summary>
        /// <param name="context">Ссылка на контекст базы данных с помощю иньекции зависимостей</param>
        public ProductController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        ///     Получение списка продуктов по идентификатору подкатегории
        /// </summary>
        /// <param name="subcategoryId">Идентификатор подкатегории</param>
        /// <returns>
        ///     Ошибку 404 если подкатегория продуктов не найдена
        ///     Успех 200 со списком продуктов если подкатегория найдена
        /// </returns>
        [HttpGet("{subcategoryId}/all-products")]
        [AllowAnonymous]
        public ActionResult<List<Product>> GetProductsBySubCategory(int subcategoryId, SortByEnum sortBy = SortByEnum.ByName, string search = "")
        {
            if (_dbContext.SubCategory.FirstOrDefault(s => s.Id == subcategoryId) == null)
            {
                return NotFound();
            }

            var products = _dbContext.Product.Where(c => c.SubCategoryId == subcategoryId).ToList();

            // Сортировка по SortByEnum
            switch (sortBy)
            {
                case SortByEnum.ByName:
                    products = products.OrderBy(c => c.Name).ToList();
                    break;
                case SortByEnum.ByPrice:
                    products = products.OrderBy(c => c.Price).ToList();
                    break;
                case SortByEnum.ByRating:
                    products = products.OrderBy(c => c.Reviews).ToList();//Нужно доработать
                    break;
            }

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return Ok(products);
        }

        /// <summary>
        ///     Получение продукта
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <returns>
        ///     Ошибку 404 если продукт не найден
        ///     Успех 200 с продуктом если он найден
        /// </returns>
        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await _dbContext.Product.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        ///     Добавление продукта только для админа
        /// </summary>
        /// <param name="productDTO">Создаваемый объект продукта</param>
        /// <returns>
        ///     Успех 201 с маршрутом где можно его получить
        /// </returns>
        [HttpPost("add-product")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddProduct(ProductDTO productDTO)
        { 
            if (productDTO == null)
            {
                return BadRequest("There are no product data to add");
            }

            var newProduct = new Product();

            newProduct.Name = productDTO.Name;
            newProduct.ImageURL = productDTO.ImageURL;
            newProduct.SubCategoryId = productDTO.SubCategoryId;
            newProduct.Description = productDTO.Description;
            newProduct.Price = productDTO.Price;

            _dbContext.Product.Add(newProduct);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("GetProductById", new {productId = newProduct.Id}, newProduct);
        }

        /// <summary>
        ///     Удаление продукта только для админа
        /// </summary>
        /// <param name="productId">Идентификатор продукта</param>
        /// <returns>
        ///     Ошибку 404 если продукт не найден
        ///     Успех 202 если продукт успешно удалён
        /// </returns>
        [HttpDelete("del-product/{productId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteProduct(int productId)
        {
            var product = _dbContext.Product
                .Include(p => p.Reviews)    
                .Include(p => p.ShoppingCartProducts)
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Entry(product).State = EntityState.Detached;

            foreach (var review in product.Reviews)
            {
                _dbContext.Entry(review).State = EntityState.Detached;
            }
            foreach (var shoppingCartProduct in product.ShoppingCartProducts)
            {
                _dbContext.Entry(shoppingCartProduct).State = EntityState.Detached;
            }
            foreach (var review in product.Reviews)
            {
                _dbContext.Reviews.Remove(review);
            }
            foreach (var shoppingCartProduct in product.ShoppingCartProducts)
            {
                _dbContext.ShoppingCartProducts.Remove(shoppingCartProduct);
            }

            _dbContext.Product.Remove(product);
            _dbContext.SaveChanges();

            return Accepted($"The {product.Name} has been deleted");
        }

        /// <summary>
        ///     Обновление продукта только для админа
        /// </summary>
        /// <param name="updatedProductDTO">объект с обновлёнными данными продукта</param>
        /// <returns>
        ///     Ошибка 404 если обновляемый продукт не найден
        ///     Успех 201 с маршрутом где можно его получить
        /// </returns>
        [HttpPut("upd-product/{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditProduct(int productId, [FromBody] ProductDTO updatedProductDTO)
        {
            try
            {
                var existingProduct = await _dbContext.Product.FindAsync(productId);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Обновление свойств продукта
                existingProduct.Name = updatedProductDTO.Name;
                existingProduct.ImageURL = updatedProductDTO.ImageURL;
                existingProduct.SubCategoryId = updatedProductDTO.SubCategoryId;
                existingProduct.Description = updatedProductDTO.Description;
                existingProduct.Price = updatedProductDTO.Price;


                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
