using Swagger.Model;
using Swagger.Models.ModelsDTO;
using System.Security.Claims;

namespace WebStore.Services.Interfacies;

/// <summary>
/// Представляет репозиторий пользователей.
/// </summary>
public interface IUserRepository
{
    #region Методы

    /// <summary>
    /// Проверяет, уникально ли имя пользователя.
    /// </summary>
    /// <param name="username">Имя пользователя для проверки.</param>
    /// <returns>True, если имя пользователя уникально, иначе - false.</returns>
    bool IsUniqueUser(string username);

    /// <summary>
    /// Выполняет вход пользователя.
    /// </summary>
    /// <param name="loginRequestDTO">DTO для запроса входа.</param>
    /// <returns>DTO ответа на запрос входа.</returns>
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

    /// <summary>
    /// Регистрирует нового пользователя.
    /// </summary>
    /// <param name="registrationRequestDTO">DTO для запроса регистрации.</param>
    /// <returns>Зарегистрированный пользователь.</returns>
    Task<User> Register(RegistrationRequestDTO registrationRequestDTO);

    /// <summary>
    /// Авторизует пользователя.
    /// </summary>
    /// <param name="loginResponseDTO">DTO для запроса создания токена.</param>
    /// <returns>Авторезированный пользователь.</returns>
    ClaimsIdentity ClaimsIdentity(LoginResponseDTO loginResponseDTO);

    #endregion
}
