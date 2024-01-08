using FilmService.Application.Services.Dto;

namespace FilmService.Application.Services.Interfaces;

public interface IFilmService
{
    Task<FilmResponse> GetFilmByIdAsync(Guid id);
    Task<FilmResponse[]> GetFilmsByTitleAsync(string title);
    Task<Guid> CreateFilmAsync(CreateFilmRequest request);
    Task UpdateFilmAsync(UpdateFilmRequest request);
    Task DeleteFilmAsync(Guid id);
}