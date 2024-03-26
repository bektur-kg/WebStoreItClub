using Swagger.Model;
using System.ComponentModel.DataAnnotations;

namespace Swagger.Models.ModelsDTO;

/// <summary>
/// Представляет DTO для ответа на запрос аутентификации.
/// </summary>
public class LoginResponseDTO
{
    #region Свойства

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    [StringLength(100)]
    [Required]
    public string UserName { get; set; } = String.Empty;

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    [StringLength(200)]
    [Required]
    public string FirstName { get; set; } = String.Empty;

    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    [StringLength(200)]
    [Required]
    public string LastName { get; set; } = String.Empty;

    /// <summary>
    /// Дата создания пользователя.
    /// </summary>
    public DateTime DoC { get; set; }

    /// <summary>
    /// Адрес пользователя.
    /// </summary>
    [StringLength(600)]
    [Required]
    public string Address { get; set; } = String.Empty;

    /// <summary>
    /// Роли пользователя.
    /// </summary>
    public required string Roles { get; set; }

    #endregion
}