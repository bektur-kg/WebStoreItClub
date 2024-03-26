namespace Swagger.Models.ModelsDTO;

/// <summary>
/// Представляет DTO для обновления информации о пользователе.
/// </summary>
public class UsersDataDTO
{
    #region Свойства

    /// <summary>
    /// Новое имя пользователя.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Новое имя пользователя.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Новая фамилия пользователя.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Новый пароль пользователя.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Новый адрес пользователя.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Новая роль пользователя.
    /// </summary>
    public string Roles { get; set; }

    #endregion
}
