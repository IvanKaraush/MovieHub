using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Primitives;
using PersonService.Application.Services.Dto.ReferalDto;
using PersonService.Application.Services.Interfaces;

namespace PersonService.Application.Services.Services;

public class ReferalService : IReferalService
{
    private readonly IReferalRepository _referalRepository;
    private readonly IMapper _mapper;

    public ReferalService(IReferalRepository referalRepository, IMapper mapper)
    {
        _referalRepository = referalRepository;
        _mapper = mapper;
    }

    public async Task<ReferalResponse> GetReferalByReferalId(Guid referalId)
    {
        var referal = await _referalRepository.GetByIdAsync(referalId) ??
                      throw new ReferalNotFoundException(DomainExceptionMessages.ReferalNotFoundException);

        return _mapper.Map<ReferalResponse>(referal);
    }
        
    public async Task CreateReferal(CreateReferalRequest request)
    {
        var referal = new Referal(Guid.NewGuid(), request.ReferalId, request.ReferalName, request.PersonName);

        _referalRepository.Add(referal);
        await _referalRepository.SaveChangesAsync();
    }
}