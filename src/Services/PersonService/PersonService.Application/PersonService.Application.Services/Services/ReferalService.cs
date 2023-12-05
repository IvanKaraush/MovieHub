using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Primitives;
using PersonService.Application.Services.Dto.ReferalDto;
using PersonService.Application.Services.Interfaces;

namespace PersonService.Application.Services.Services
{
    public class ReferalService : IReferalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReferalRepository _referalRepository;
        private readonly IMapper _mapper;

        public ReferalService(IUnitOfWork unitOfWork, IReferalRepository referalRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _referalRepository = referalRepository;
            _mapper = mapper;
        }

        public async Task<ReferalResponse> GetReferalByReferalId(Guid referalId)
        {
            var referal = await _referalRepository.GetByIdAsync(referalId) ??
                          throw new ReferalNotFoundException(DomainExceptionMessages.ReferalNotFoundException);

            return _mapper.Map<ReferalResponse>(referal);
        }


        /*public async Task<Guid> ReplenishIncome(Referal referal, decimal income)
        {
            referal.income += income;
            _unitOfWork.repository.Update(referal);
            await _unitOfWork.Save();
            return referal.PersonId;
        }*/

        public async Task CreateReferal(CreateReferalRequest request)
        {
            var referal = new Referal(Guid.NewGuid(), request.ReferalId, request.ReferalName, request.PersonName);

            _referalRepository.Add(referal);
            await _unitOfWork.SaveChangesAsync();
        }
        // todo: Дополнить метод
        /*public async Task ReplenishPersonBalanceByReferalId(ReplenishPersonBalanceRequest request)
        {
            var referal = await _referalRepository.GetAsync(c => c.Id == request.id);
            if (referal == null)
            {
                return;
            }
            //await _PersonService.ReplenishBalance(replenishPersonBalanceDTO);

            _unitOfWork.repository.Update(referal);
            await _unitOfWork.Save();
        }*/
    }
}