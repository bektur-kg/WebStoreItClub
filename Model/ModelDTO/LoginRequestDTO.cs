using System.ComponentModel.DataAnnotations;

namespace Swagger.Models.ModelsDTO;

/// <summary>
/// Представляет DTO для запроса входа в систему.
/// </summary>
public class LoginRequestDTO
{
    #region Свойства

    /// <summary>
    /// Имя пользователя, введенное при входе.
    /// </summary>
    [Required]
    public string UserName { get; set; }

    /// <summary>
    /// Пароль, введенный при входе.
    /// </summary>
    [Required]
    public string Password { get; set; }

    #endregion
}