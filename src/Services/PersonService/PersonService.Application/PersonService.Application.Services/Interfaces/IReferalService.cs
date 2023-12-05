using PersonService.Application.Services.Dto.ReferalDto;

namespace PersonService.Application.Services.Interfaces
{
    public interface IReferalService
    {
        Task<ReferalResponse> GetReferalByReferalId(Guid referalId);
        /*Task<Guid> ReplenishIncome(Referal referal, decimal income);
        Task ReplenishPersonBalanceByReferalId(ReplenishPersonBalanceRequest replenishPersonBalanceRequest);*/
        Task CreateReferal(CreateReferalRequest request);
    }
}