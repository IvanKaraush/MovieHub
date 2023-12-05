namespace PersonService.Application.Services.Dto.PersonDto;

public class WithdrawalOfFundsRequest : BasePerson
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Сумма на которую пользователь пополняет баланс
    /// </summary>
    public int Money { get; init; }
}