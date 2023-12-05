using AutoMapper;
using Domain.Entities;
using PersonService.Application.Services.Dto.PersonDto;
using PersonService.Application.Services.Dto.ReferalDto;

namespace PersonService.Application.Services.Mappers;

public class MappingPersonProfile : Profile
{
    public MappingPersonProfile()
    {
        CreateMap<Person, PersonResponse>();
        CreateMap<Referal, ReferalResponse>();
    }
}