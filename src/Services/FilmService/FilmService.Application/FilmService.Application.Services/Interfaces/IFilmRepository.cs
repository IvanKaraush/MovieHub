using FilmService.Domain.Entities;

namespace FilmService.Application.Services.Interfaces;

public interface IFilmRepository
{
    Task<Film?> GetByIdAsync(Guid id);
    void Add(Film film);
    void Update(Film film);
    void Delete(Film id);
    Task SaveChangesAsync();
}