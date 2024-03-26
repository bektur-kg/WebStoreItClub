using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.ModelDTO;
using WebStore.Model;

namespace WebStore.Controllers;

[Authorize(Roles = "User")]
[Route("api/shopping")]
[ApiController]
public class ShoppingController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    public ShoppingController(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("all-shopping-products")]
    public async Task<IActionResult> GetShoppingProducts()
    {
        var user = HttpContext.User.Identity.Name;
        var currentUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.UserName == user);
        var products = await _dbContext.ShoppingCartProducts.
                Include(p => p.Product).
                Where(p => p.ShoppingCarts.Name == "Shopping Busket" && p.ShoppingCarts.UserId == currentUser.Id).
                ToListAsync();

        if (products == null)
            return NotFound();

        return Ok(products);
    }

    [HttpPost("buy-products")]
    public async Task<IActionResult> AddShoppingCart()
    {
        var user = HttpContext.User.Identity.Name;
        var currentUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == user);
        if (currentUser == null)
            return BadRequest();

        var shoppingCart = await _dbContext.ShoppingCarts
            .Include(sc => sc.ShoppingCartProducts)
            .ThenInclude(scp => scp.Product)
            .FirstOrDefaultAsync(sc => sc.Name == "Shopping Busket" && sc.UserId == currentUser.Id);

        if (shoppingCart == null)
            return BadRequest();

        // Соберите список продуктов из корзины пользователя
        var products = shoppingCart.ShoppingCartProducts.Select(scp => scp.Product).ToList();

        // Получите адрес пользователя
        var userAddress = currentUser.Address;

        // Удалите все продукты из корзины покупок
        _dbContext.ShoppingCartProducts.RemoveRange(shoppingCart.ShoppingCartProducts);
        await _dbContext.SaveChangesAsync();

        return Ok($"Покупка успешно совершена. Продукты будут доставлены по адресу: {userAddress}");
    }
}
