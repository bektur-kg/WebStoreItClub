using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Model;
using WebStore.ModelDTO;

namespace WebStore.Controllers
{
    /// <summary>
    ///     Контроллер управляющий подкатегориями
    /// </summary>
    [Route("api/sub-categories")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        ///     Инициализирует контекст базы данных <see cref="ApplicationDbContext"/>
        /// </summary>
        /// <param name="context">Ссылка на контекст базы данных с помощю иньекции зависимостей</param>
        public SubCategoryController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        ///     Удаляет подкатегорию
        /// </summary>
        /// <param name="subCategoryId">Идентификатор подкатегории</param>
        /// <returns>
        ///     Ошибку 404 если подкатегория не найдена
        ///     Успех 204 если подкатегория успешно удалена
        /// </returns>
        [HttpDelete("{subCategoryId}/del-sub-category")]
        public IActionResult DeleteSubCategory(int subCategoryId)
        {
            var subcategoryToDelete = _dbContext.SubCategory.FirstOrDefault(s => s.Id == subCategoryId);

            if (subcategoryToDelete == null)
            {
                return NotFound();
            }

            _dbContext.SubCategory.Remove(subcategoryToDelete);
            _dbContext.SaveChanges();

            return NoContent();
        }

        /// <summary>
        ///     Обновляет подкатегорию
        /// </summary>
        /// <param name="subCategoryId">Идентификатор подкатегории</param>
        /// <param name="subCategory">Обновленный объект подкатегории</param>
        /// <returns>
        ///     Ошибку 404 если подкатегория не найдена
        ///     Успех 204 если подкатегория успешно обновлена
        /// </returns>
        [HttpPut("{subCategoryId}/upd-sub-category")]
        public IActionResult UpdateSubcategory(int subCategoryId, SubCategoryUpdateDTO subCategory)
        {
            var subcategoryToUpdate = _dbContext.SubCategory.FirstOrDefault(s => s.Id == subCategoryId);
            var doesMainCategoryIdExist = _dbContext.MainCategory.Any(c => c.Id == subCategory.MainCategoryId);

            if (subcategoryToUpdate == null || !doesMainCategoryIdExist)
            {
                return NotFound();
            }

            subcategoryToUpdate.Name = subCategory.Name;
            subcategoryToUpdate.IconURL = subCategory.IconURL;
            subcategoryToUpdate.ImageURL = subCategory.ImageURL;
            subcategoryToUpdate.MainCategoryId = subCategory.MainCategoryId;

            _dbContext.SaveChanges();

            return NoContent();
        }

        /// <summary>
        ///     Создаёт подкатегорию
        /// </summary>
        /// <param name="subCategory">Создаваемый объект подкатегории</param>
        /// <returns>
        ///     Ошибку 404 если родительская категория подкатегории не найдена
        ///     Успех 201 если подкатегория успешно создана
        /// </returns>
        [HttpPost("add-sub-category")]
        public IActionResult CreateSubCategory(SubCategoryCreationDto subCategory)
        {
            var doesMainCategoryIdExist = _dbContext.MainCategory.Any(c => c.Id == subCategory.MainCategoryId);

            if (!doesMainCategoryIdExist)
            {
                return NotFound();
            }

            var newSubcategory = new SubCategory()
            {
                Name = subCategory.Name,
                MainCategoryId = subCategory.MainCategoryId,
                ImageURL = subCategory.ImageURL,
                IconURL = subCategory.IconURL,
            };

            _dbContext.SubCategory.Add(newSubcategory);
            _dbContext.SaveChanges();

            return Created();
        }
    }
}
