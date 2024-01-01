using PersonService.Application.Services.Dto.ReferralDto;

namespace PersonService.Application.Services.Interfaces;

public interface IReferralService
{
    Task<ReferralResponse> GetReferralByReferralId(Guid referralId);
    Task CreateReferral(CreateReferralRequest request);
}