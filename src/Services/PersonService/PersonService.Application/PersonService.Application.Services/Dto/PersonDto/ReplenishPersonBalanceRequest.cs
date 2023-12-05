namespace PersonService.Application.Services.Dto.PersonDto;

public class ReplenishPersonBalanceRequest
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; init; }
    public decimal Balance { get; init; }
}