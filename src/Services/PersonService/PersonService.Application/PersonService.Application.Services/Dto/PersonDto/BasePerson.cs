namespace PersonService.Application.Services.Dto.PersonDto;

public class BasePerson
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; init; } = string.Empty;
}