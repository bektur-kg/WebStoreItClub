using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Model;
using WebStore.ModelDTO;

namespace WebStore.Controllers;

/// <summary>
///     Контроллер управляющий категориями
/// </summary>
[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    ///     Инициализирует контекст базы данных <see cref="ApplicationDbContext"/>
    /// </summary>
    /// <param name="context">Ссылка на контекст базы данных с помощю иньекции зависимостей</param>
    public CategoryController(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    /// <summary>
    ///     Получение категорий с их подкатегориями
    /// </summary>
    /// <returns>
    ///     Успех 200 с списком категорий и их подкатегорий
    /// </returns>
    [HttpGet("all-categories")]
    [AllowAnonymous]
    public ActionResult GetCateogiries()
    {
        return Ok(_dbContext.MainCategory
            .Include(p => p.SubCategory)
            .ToList());
    }

    /// <summary>
    ///     Создание категории только для админа
    /// </summary>
    /// <param name="category">Создаваемый объект категории</param>
    /// <returns>
    ///     Успех 201 если категория успешно добавлена
    /// </returns>
    [HttpPost("add-category")]
    [Authorize(Roles = "Admin")]
    public IActionResult AddCategory(CategoryCreationDto category)
    {
        var newCategory = new MainCategory()
        {
            Name = category.Name,
        };

        _dbContext.MainCategory.Add(newCategory);
        _dbContext.SaveChanges();

        return Created();
    }

    /// <summary>
    ///     Обновление категории только для админа
    /// </summary>
    /// <param name="category">Обновлённый объект категории</param>
    /// <param name="categoryId">Идентификатор категории</param>
    /// <returns>
    ///     Ошибку 404 если категория не найдена
    ///     Успех 204 если категория успешно обновлена
    /// </returns>
    [HttpPut("{categoryId}/upd-category")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateCategory(CategoryUpdateDto category, int categoryId)
    {
        var categoryToUpdate = _dbContext.MainCategory.FirstOrDefault(c => c.Id == categoryId);

        if (categoryToUpdate == null)
        {
            return NotFound();
        }

        categoryToUpdate.Name = category.Name;

        _dbContext.SaveChanges();
        return NoContent();
    }
}
