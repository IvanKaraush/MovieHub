
namespace PersonService.Application.Services.Dto.ReferalDto
{
    public class ReferalResponse
    {
        public Guid PersonId { get; init; }
        public string PersonName { get; init; } = string.Empty;
        public string ReferalName { get; init; } = string.Empty;
        public Guid ReferalId { get; init; }
    }
}
