using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swagger.Model;

/// <summary>
/// Представляет сущность пользователя.
/// </summary>
public class User
{
    #region Свойства

    /// <summary>
    /// Уникальный идентификатор пользователя.
    /// </summary>
    [Key]
    [JsonIgnore]
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    [StringLength(100)]
    [Required]
    public string UserName { get; set; } = String.Empty;

    /// <summary>
    /// Хэш пароля пользователя.
    /// </summary>
    [StringLength(500)]
    [Required]
    public string PasswordHash { get; set; } = String.Empty;

    /// <summary>
    /// Соль для хэширования пароля пользователя.
    /// </summary>
    [StringLength(500)]
    [Required]
    public string Salt { get; set; } = String.Empty;

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
    [Required]
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
    public required string Roles { get; set; } = "User";

    #endregion
}
