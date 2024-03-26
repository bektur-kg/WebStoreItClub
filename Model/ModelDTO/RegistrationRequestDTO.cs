using System.ComponentModel.DataAnnotations;

namespace Swagger.Models.ModelsDTO;

/// <summary>
/// Представляет DTO для запроса регистрации пользователя.
/// </summary>
public class RegistrationRequestDTO
{
    #region Свойства

    /// <summary>
    /// Ник пользователя.
    /// </summary>
    [Required]
    public string UserName { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    [Required]
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    [Required]
    public string LastName { get; set; }

    /// <summary>
    /// Пароль, выбранный при регистрации.
    /// </summary>
    [Required]
    public string Password { get; set; }

    /// <summary>
    /// Адрес, указанный при регистрации.
    /// </summary>
    [Required]
    public string Address { get; set; }

    #endregion
}