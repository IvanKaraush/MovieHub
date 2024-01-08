using Ardalis.GuardClauses;
using AutoMapper;
using FilmService.Application.Services.Dto;
using FilmService.Application.Services.Exceptions;
using FilmService.Application.Services.Interfaces;
using FilmService.Application.Services.Primitives;
using FilmService.Domain.Entities;

namespace FilmService.Application.Services.Services;

public class FilmService : IFilmService
{
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public FilmService(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }

    public async Task<FilmResponse> GetFilmByIdAsync(Guid id)
    {
        Guard.Against.Default(id, nameof(id));

        var film = await _filmRepository.GetByIdAsync(id) ??
                   throw new FilmNotFoundException(ApplicationExceptionMessages.FilmNotFound);

        return _mapper.Map<FilmResponse>(film);
    }

    public async Task<FilmResponse[]> GetFilmsByTitleAsync(string title)
    {
        Guard.Against.NullOrEmpty(title, nameof(title));

        var films = await _filmRepository.GetByFilterAsync(c => c.Title.Contains(title));
        if (films.Length == 0)
        {
            throw new FilmNotFoundException(ApplicationExceptionMessages.FilmNotFound);
        }

        return _mapper.Map<FilmResponse[]>(films);
    }

    public async Task<Guid> CreateFilmAsync(CreateFilmRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var newFilm = new Film(Guid.NewGuid(), request.Title, request.Description, request.Url);
        _filmRepository.Add(newFilm);

        await _filmRepository.SaveChangesAsync();
        return newFilm.Id;
    }

    public async Task UpdateFilmAsync(UpdateFilmRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var film = await _filmRepository.GetByIdAsync(request.Id) ??
                   throw new FilmNotFoundException(ApplicationExceptionMessages.FilmNotFound);

        film.Update(request.Title, request.Description, request.Url);

        await _filmRepository.SaveChangesAsync();
    }

    public async Task DeleteFilmAsync(Guid id)
    {
        Guard.Against.Default(id, nameof(id));

        var film = await _filmRepository.GetByIdAsync(id) ??
                   throw new FilmNotFoundException(ApplicationExceptionMessages.FilmNotFound);
        _filmRepository.Delete(film);

        await _filmRepository.SaveChangesAsync();
    }
}