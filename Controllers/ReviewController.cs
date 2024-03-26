using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swagger.Models;
using System.Net;
using WebStore.Model;

namespace WebStore.Controllers;

[Route("api/review")]
[Authorize(Roles = "User")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    protected APIResponse _response;

    public ReviewController(ApplicationDbContext context)
    {
        _dbContext = context;
        this._response = new();
    }

    [HttpGet("{productId}/all-reviews")]
    public ActionResult<IEnumerable<Reviews>> GetProductReviews(int productId)
    {
        // Используйте контекст данных для получения отзывов для конкретного продукта
        var reviews = _dbContext.Reviews.Where(r => r.ProductId == productId).ToList();

        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        _response.Result = reviews;
        return Ok(_response);
    }

    [HttpPost("{productId}/add-review")]
    public async Task<ActionResult<Reviews>> AddReview(int productId, Reviews review)
    {
        var user = HttpContext.User.Identity.Name;
        var currentUser = _dbContext.Users.FirstOrDefault(u => u.UserName == user);
        var product = await _dbContext.Product.FindAsync(productId);

        if (review == null)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = true;
            _response.ErrorMessages.Add("Отсутствуют данные о отзыве для добавления");
            return BadRequest(_response);
        }

        //bektur's method

        review.Name = currentUser.FirstName + currentUser.LastName;
        review.ProductId = product.Id;
        review.UserId = currentUser.Id;

        _dbContext.Reviews.Add(review);

        // Обновляем существующий продукт
        var reviewsForProduct = _dbContext.Reviews.Where(r => r.ProductId == productId);
        if (reviewsForProduct.Any())
        {
            var averageGrade = (int)reviewsForProduct.Average(r => r.Grade);
            if(averageGrade > 10)
                product.Grade = 10;
            else
                product.Grade = averageGrade;
        }
        else
        {
            product.Grade = 0;
        }

        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductReviews), new { productId }, review);
    }

    [HttpDelete("{productId}/del-review/{reviewId}")]
    public async Task<ActionResult> DeleteReview(int productId, int reviewId)
    {
        var review = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.Id == reviewId);
        var product = await _dbContext.Product.FindAsync(productId);

        if (review == null || product == null)
        {
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.IsSuccess = true;
            return NotFound(_response);
        }

        if (review.ProductId != productId)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = true;
            _response.ErrorMessages.Add("Идентификатор продукта не соответствует существующему отзыву");
            return BadRequest(_response);
        }

        _dbContext.Reviews.Remove(review);
        await _dbContext.SaveChangesAsync();

        // Пересчитываем среднюю оценку продукта без учёта удалённого отзыва
        var remainingReviews = await _dbContext.Reviews.Where(r => r.ProductId == productId).ToListAsync();
        if (remainingReviews.Any())
        {
            var averageGrade = (int)remainingReviews.Average(r => r.Grade);
            if (averageGrade > 10)
                product.Grade = 10;
            else
                product.Grade = averageGrade;
        }
        else
        {
            product.Grade = 0;
        }

        await _dbContext.SaveChangesAsync();

        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        return Ok(_response);
    }

    [HttpPut("{productId}/upd-review/{reviewId}")]
    public async Task<ActionResult<Reviews>> UpdateReview(int productId, int reviewId, Reviews updatedReview)
    {
        var product = await _dbContext.Product.FindAsync(productId);

        if (updatedReview == null || product == null)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = true;
            return BadRequest(_response);
        }

        var existingReview = await _dbContext.Reviews.FindAsync(reviewId);

        if (existingReview == null)
        {
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.IsSuccess = true;
            return NotFound(_response);
        }

        existingReview.Name = updatedReview.Name;
        existingReview.Content = updatedReview.Content;
        existingReview.Grade = updatedReview.Grade;
        existingReview.ProductId = productId;

        var remainingReviews = await _dbContext.Reviews.Where(r => r.ProductId == productId).ToListAsync();
        if (remainingReviews.Any())
        {
            var averageGrade = (int)remainingReviews.Average(r => r.Grade);
            if (averageGrade > 10)
                product.Grade = 10;
            else
                product.Grade = averageGrade;
        }
        else
        {
            product.Grade = 0;
        }

        await _dbContext.SaveChangesAsync();

        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        _response.Result = existingReview;
        return Ok(_response);
    }
}
