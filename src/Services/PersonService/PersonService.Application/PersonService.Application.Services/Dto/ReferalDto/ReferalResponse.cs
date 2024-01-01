
namespace PersonService.Application.Services.Dto.ReferralDto
{
    public class ReferralResponse
    {
        public Guid PersonId { get; init; }
        public string PersonName { get; init; } = string.Empty;
        public string ReferralName { get; init; } = string.Empty;
        public Guid ReferralId { get; init; }
    }
}
