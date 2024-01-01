namespace PersonService.Application.Services.Dto.ReferralDto
{
    public class CreateReferralRequest
    {
        public string PersonName { get; init; } = string.Empty;
        public string ReferralName { get; init; } = string.Empty;
        public Guid ReferralId { get; init; }
    }
}