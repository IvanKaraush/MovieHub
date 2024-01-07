using AutoMapper;
using FilmService.Application.Services.Dto;
using FilmService.Domain.Entities;

namespace FilmService.Application.Services.Mappers;

public class MappingFilmProfile : Profile
{
    public MappingFilmProfile()
    {
        CreateMap<Film, FilmResponse>();
    }
}