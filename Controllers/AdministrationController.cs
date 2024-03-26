using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Swagger.Models.ModelsDTO;
using Swagger.Repository;
using Swagger.Models;
using System.Net;
using WebStore;
using Azure;
using WebStore.Services.Interfacies;

namespace Swagger.Controllers;

/// <summary>
/// Контроллер, отвечающий за административные функции.
/// </summary>
[Route("api/admin")]
[Authorize(Roles = "Admin")]
[ApiController]
public class AdministrationController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<AdministrationController> _logger;
    protected APIResponse _response;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="AdministrationController"/>.
    /// </summary>
    /// <param name="userRepository">Репозиторий пользователей.</param>
    /// <param name="dbContext">Контекст базы данных приложения.</param>
    /// <param name="logger">Логгер.</param>
    public AdministrationController(IUserRepository userRepository, ApplicationDbContext dbContext, ILogger<AdministrationController> logger)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._response = new();
    }

    /// <summary>
    /// Получает список пользователей.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("all-users")]
    public async Task<ActionResult> GetUsersList()
    {
        try
        {
            var currentUser = HttpContext.User.Identity.Name;
            var users = await _dbContext.Users
                .Where(u => u.UserName != currentUser)
                .ToListAsync();

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = users;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка при получении списка пользователей.");
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Произошла внутренняя ошибка сервера при получении списка пользователей.");
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }

    /// <summary>
    /// Добавляет нового пользователя.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("add-user")]
    public async Task<ActionResult> AddUser([FromBody] RegistrationRequestDTO model)
    {
        try
        {
            bool isUserNameUnique = _userRepository.IsUniqueUser(model.UserName);
            if (!isUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Имя пользователя уже занято");
                return BadRequest(_response);
            }

            var user = await _userRepository.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Ошибка при регистрации");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = user;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка при добавлении нового пользователя.");
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Произошла внутренняя ошибка сервера при добавлении нового пользователя.");
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }

    /// <summary>
    /// Удаляет пользователя.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("del-user/{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            var currentUser = HttpContext.User.Identity.Name;
            if (user.UserName == currentUser)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Вы не можете удалить себя.");
                return BadRequest(_response);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = false;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка при удалении пользователя.");
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Произошла внутренняя ошибка сервера при удалении пользователя.");
            return StatusCode((int) HttpStatusCode.InternalServerError, _response);
        }
    }

    /// <summary>
    /// Обновляет информацию о пользователе.
    /// </summary>
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPut("upd-user/{id}")]
    public async Task<IActionResult> UpdateUser(int id, UsersDataDTO user)
    {
        try {
            var existingUser = await _dbContext.Users.FindAsync(id);
            if (existingUser == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }

            try
            {
                _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                else
                {
                    throw;
                }
            }

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = false;
            _response.Result = existingUser;
            return Ok(_response);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Произошла ошибка при обновлении о данных пользователя.");
            _response.StatusCode = HttpStatusCode.InternalServerError;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Произошла внутренняя ошибка сервера при обновлении данных пользователя.");
            return StatusCode((int)HttpStatusCode.InternalServerError, _response);
        }
    }

    private bool UserExists(int id)
    {
        return _dbContext.Users.Any(e => e.Id == id);
    }
}
