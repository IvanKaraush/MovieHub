using System.Linq.Expressions;
using Ardalis.GuardClauses;
using FilmService.Application.Services.Interfaces;
using FilmService.Domain.Entities;
using FilmService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FilmService.Infrastructure.Repositories.Repositories;

public class FilmRepository : IFilmRepository
{
    private readonly ApplicationContext _context;

    public FilmRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Film?> GetByIdAsync(Guid id)
    {
        return await _context.Films.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Film[]> GetByFilterAsync(Expression<Func<Film, bool>> filter)
    {
        return await _context.Films.Where(filter).ToArrayAsync();
    }

    public void Add(Film film)
    {
        Guard.Against.Null(film, nameof(film));

        _context.Films.Add(film);
    }

    public void Update(Film film)
    {
        Guard.Against.Null(film, nameof(film));

        _context.Films.Update(film);
    }

    public void Delete(Film film)
    {
        Guard.Against.Null(film, nameof(film));

        _context.Films.Remove(film);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}