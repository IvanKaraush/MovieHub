using PersonService.Application.Services.Dto.ReferalDto;

namespace PersonService.Application.Services.Interfaces;

public interface IReferalService
{
    Task<ReferalResponse> GetReferalByReferalId(Guid referalId);
    Task CreateReferal(CreateReferalRequest request);
}