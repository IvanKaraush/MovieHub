using PersonService.Application.Services.Dto.ReferalDto;

namespace PersonService.Application.Services.Dto.PersonDto;

public class PersonResponse : BasePerson
{
    public Guid Id { get; init; }
    public string Email { get; init; } = string.Empty;
    public decimal Balance { get; init; }
    public string WalletName { get; init; } = string.Empty;
    public ReferalResponse[] Referals { get; init; } = Array.Empty<ReferalResponse>();
}