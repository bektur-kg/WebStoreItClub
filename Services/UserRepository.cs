using Swagger.Models.ModelsDTO;
using Swagger.Models;
using Swagger.Model;
using WebStore;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WebStore.Services.Interfacies;

namespace Swagger.Repository;

/// <summary>
/// Репозиторий пользователей, реализующий интерфейс <see cref="IUserRepository"/>.
/// </summary>
public class UserRepository : IUserRepository
{
    #region Поля

    private readonly ApplicationDbContext _dbContext;
    protected APIResponse _response;

    #endregion

    #region Конструктор

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="context">Контекст базы данных приложения.</param>
    /// <param name="configuration">Конфигурация приложения.</param>
    public UserRepository(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    #endregion

    #region Методы

    /// <summary>
    /// Проверяет, уникально ли имя пользователя.
    /// </summary>
    /// <param name="username">Имя пользователя для проверки.</param>
    /// <returns>True, если имя пользователя уникально, иначе - false.</returns>
    public bool IsUniqueUser(string username)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

        if (user == null)
            return true;

        return false;
    }

    /// <summary>
    /// Выполняет вход пользователя.
    /// </summary>
    /// <param name="loginRequestDTO">DTO для запроса входа.</param>
    /// <returns>DTO ответа на запрос входа.</returns>
    public async Task<LoginResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
    {
        var user = _dbContext.Users.FirstOrDefault(u =>
            u.UserName.ToLower() == loginRequestDTO.UserName.ToLower()
        );

        if (user != null)
        {
            // Используем соль из базы данных для проверки пароля
            var password = BCrypt.Net.BCrypt.HashPassword(loginRequestDTO.Password, user.Salt);
            bool isPasswordValid = password == user.PasswordHash;

            if (isPasswordValid)
                return new LoginResponseDTO
                {
                    UserName = user.UserName,
                    Address = user.Address,
                    DoC = user.DoC,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = user.Roles
                };
        }

        // Если пользователь не найден или пароль неверный, null вместо данных пользователя
        return null;
    }

    /// <summary>
    /// Регистрирует нового пользователя.
    /// </summary>
    /// <param name="registrationRequestDTO">DTO для запроса регистрации.</param>
    /// <returns>Зарегистрированный пользователь.</returns>
    public async Task<User> Register(RegistrationRequestDTO registrationRequestDTO)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(registrationRequestDTO.Password, salt);
        
        string role = "User";
        User user = new()
        {
            UserName = registrationRequestDTO.UserName,
            PasswordHash = passwordHash,
            Salt = salt,
            FirstName = registrationRequestDTO.FirstName,
            LastName = registrationRequestDTO.LastName,
            Address = registrationRequestDTO.Address,
            DoC = DateTime.Now.AddDays(5),
            Roles = role,
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public ClaimsIdentity ClaimsIdentity(LoginResponseDTO loginResponseDTO)
    {
        var user = _dbContext.Users.FirstOrDefault(u =>
            u.UserName.ToLower() == loginResponseDTO.UserName.ToLower()
        );

        var claims = new List<Claim>() {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Name, loginResponseDTO.UserName),
                    new(ClaimTypes.Role, loginResponseDTO.Roles.ToString()),
                    new(ClaimTypes.GivenName, loginResponseDTO.FirstName + " " + loginResponseDTO.LastName),
                };

        var claimsIdentity = new ClaimsIdentity(claims, "cookie");
        return claimsIdentity;
    }
    #endregion
}
