using System.Net;

namespace Swagger.Models;

/// <summary>
/// Представляет ответ API.
/// </summary>
public class APIResponse
{
    #region Поля и свойства

    /// <summary>
    /// HTTP статус код ответа.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Указывает, успешен ли запрос.
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Результат запроса.
    /// </summary>
    public object Result { get; set; }

    /// <summary>
    /// Список сообщений об ошибках.
    /// </summary>
    public List<string> ErrorMessages { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="APIResponse"/> с пустым списком сообщений об ошибках.
    /// </summary>
    public APIResponse()
    {
        ErrorMessages = new List<string>();
    }

    #endregion
}
