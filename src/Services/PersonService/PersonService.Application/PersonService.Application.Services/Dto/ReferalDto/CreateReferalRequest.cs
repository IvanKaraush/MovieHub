namespace PersonService.Application.Services.Dto.ReferalDto
{
    public class CreateReferalRequest
    {
        public string PersonName { get; init; } = string.Empty;
        public string ReferalName { get; init; } = string.Empty;
        public Guid ReferalId { get; init; }
    }
}