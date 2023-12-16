namespace PersonService.Application.Services.Dto.PersonDto;

public class PersonRegisterRequest : BasePerson
{
    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Дата создания профиля
    /// </summary>
    public DateOnly ProfileCreatedDate { get; init; }

    /// <summary>
    /// Идентификатор приглашающего пользователя (если таковой существует)
    /// </summary>
    public Guid? PersonId { get; init; }

}