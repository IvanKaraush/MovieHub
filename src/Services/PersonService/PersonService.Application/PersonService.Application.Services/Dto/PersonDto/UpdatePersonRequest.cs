namespace PersonService.Application.Services.Dto.PersonDto;

public class UpdatePersonRequest : BasePerson
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Название кошелька пользователя
    /// </summary>
    public string WalletName { get; init; } = string.Empty;
}