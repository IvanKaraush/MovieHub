using AutoMapper;
using Domain.Entities;
using PersonService.Application.Services.Dto.PersonDto;
using PersonService.Application.Services.Dto.ReferralDto;

namespace PersonService.Application.Services.Mappers;

public class MappingPersonProfile : Profile
{
    public MappingPersonProfile()
    {
        CreateMap<Person, PersonResponse>();
        CreateMap<Referral, ReferralResponse>();
    }
}