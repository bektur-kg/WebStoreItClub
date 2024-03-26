using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.ModelDTO;
using WebStore.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebStore.Controllers
{
    [Route("api/shopping-cart-products")]
    [Authorize(Roles = "User")]
    [ApiController]
    public class ShoppingCartProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ShoppingCartProductsController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("{shoppingCartId}/all-products-shopping-cart")]
        public async Task<IActionResult> GetShoppingCartProducts(int shoppingCartId)
        {
            var user = HttpContext.User.Identity.Name;
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.UserName == user);

            var products = await _dbContext.ShoppingCartProducts.
                Include(p=>p.Product).
                Where(p=>p.ShoppingCartId == shoppingCartId && p.ShoppingCarts.UserId == currentUser.Id).
                ToListAsync();

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost("add-product-shopping-cart")]
        public async Task<IActionResult> AddProductToShoppingCart(ShoppingCartProductsDTO shoppingCartProductDTO)
        {
            var user = HttpContext.User.Identity.Name;
            var currentUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == user);
            var product = await _dbContext.Product.FindAsync(shoppingCartProductDTO.ProductId);
            if (product == null)
            {
                return NotFound($"Продукт с id {shoppingCartProductDTO.ProductId} не найден");
            }

            var newShoppingCartProduct = new ShoppingCartProducts()
            {
                ProductId = product.Id,
                ShoppingCartId = shoppingCartProductDTO.ShoppingCartId,
                Quantity = shoppingCartProductDTO.ProductQuantity,
                UserId = currentUser.Id,
            };
            _dbContext.ShoppingCartProducts.Add(newShoppingCartProduct);
            await _dbContext.SaveChangesAsync();


            return Ok($"Успешно добавлено в корзину");
        }

        [HttpDelete("{shoppingCartProductId}/del-product-shopping-cart")]
        public async Task<IActionResult> DeleteShoppingCartProduct(int shoppingCartProductId)
        {
            var user = HttpContext.User.Identity.Name;
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.UserName == user);

            var shoppingCartProductToDelete = _dbContext.ShoppingCartProducts
                .FirstOrDefault(p => p.Id == shoppingCartProductId && p.UserId == currentUser.Id);

            if (shoppingCartProductToDelete == null)
            {
                return NotFound();
            }

            // Delete Product
            _dbContext.ShoppingCartProducts.Remove(shoppingCartProductToDelete);
            await _dbContext.SaveChangesAsync();

            return Ok($"Продукт удален с корзины");
        }

        [HttpPut("{shoppingCartProductId}/upd-product-shopping-cart")]
        public async Task<IActionResult> ChangeProductToShoppingCart(int shoppingCartProductId, ShoppingCartProductsDTO shoppingCartProductDTO)
        {
            var user = HttpContext.User.Identity.Name;
            var currentUser = _dbContext.Users.FirstOrDefault(u => u.UserName == user);

            var shoppingCartProductToChange = _dbContext.ShoppingCartProducts
                .FirstOrDefault(p => p.Id == shoppingCartProductId && p.UserId == currentUser.Id);

            if (shoppingCartProductToChange == null)
                return NotFound();

            shoppingCartProductToChange.Quantity = shoppingCartProductDTO.ProductQuantity;
            await _dbContext.SaveChangesAsync();

            return Ok($"Продукт успешно изменен");
        }
    }
}
