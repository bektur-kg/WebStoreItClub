using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Swagger.Models.ModelsDTO;
using Swagger.Models;
using System.Net;
using WebStore;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebStore.Services.Interfacies;

namespace Swagger.Controllers;

/// <summary>
/// Контроллер, отвечающий за управление текущим пользователем.
/// </summary>
[Route("api/user")]
[Authorize]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;
    protected APIResponse _response;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UserController"/>.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных приложения.</param>
    /// <param name="logger">Логгер.</param>
    public UserController(ApplicationDbContext dbContext, ILogger<UserController> logger, IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._response = new();
    }

    /// <summary>
    /// Получает информацию о текущем пользователе.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("current-user")]
    public async Task<ActionResult> GetCurrentUser()
    {
        try
        {
            var currentUser = HttpContext.User.Identity.Name;
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == currentUser);
            var response = new LoginResponseDTO
            {
                UserName = user.UserName,
                Address = user.Address,
                DoC = user.DoC,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.Roles
            };
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = response;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка при получении информации о текущем пользователе.");
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Произошла внутренняя ошибка сервера при получении информации о текущем пользователе.");
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }

    /// <summary>
    /// Удаляет текущего пользователя.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("del-current-user")]
    public async Task<ActionResult> DeleteCurrentUser()
    {
        try
        {
            var currentUser = HttpContext.User.Identity.Name;
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == currentUser);

            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("Получен запрос на выход.");
            await HttpContext.SignOutAsync();

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            _response.ErrorMessages.Add("Вы успешно удалили свой аккаунт.");
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка при удалении текущего пользователя.");
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Произошла внутренняя ошибка сервера при удалении текущего пользователя.");
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }

    /// <summary>
    /// Обновляет информацию о текущем пользователе.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("upd-current-user")]
    public async Task<IActionResult> UpdateCurrentUser(RegistrationRequestDTO user)
    {
        try
        {
            string? currentUser = HttpContext.User.Identity.Name;
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == currentUser);
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);

            if (existingUser == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            if (_userRepository.IsUniqueUser(user.UserName) == true)
            {
                existingUser.UserName = user.UserName;
            }
            else
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Имя пользователя уже занято");
                return BadRequest(_response);
            }

            existingUser.PasswordHash = passwordHash;
            existingUser.Salt = salt;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Address = user.Address;

            _dbContext.Entry(existingUser).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            // Проверяем, если пользователь уже аутентифицирован, то сначала выходим
            if (User.Identity.IsAuthenticated)
            {
                _logger.LogInformation("Получен запрос на выход.");
                await HttpContext.SignOutAsync();
            }

            _logger.LogInformation("Получен запрос на вход.");
            var loginResponse = await _userRepository.Login(new LoginRequestDTO
            {
                UserName = existingUser.UserName,
                Password = user.Password
            });
            await HttpContext.SignInAsync(new ClaimsPrincipal(_userRepository.ClaimsIdentity(loginResponse)));

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            _response.Result = new LoginResponseDTO
            {
                UserName = existingUser.UserName,
                Address = existingUser.Address,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                DoC = existingUser.DoC,
                Roles = existingUser.Roles
            };
            _response.ErrorMessages.Add("Информация о пользователе успешно обновлена.");
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка при обновлении информации о текущем пользователе.");
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Произошла внутренняя ошибка сервера при обновлении информации о текущем пользователе.");
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }
}
