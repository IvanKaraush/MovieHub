using System.Linq.Expressions;
using PersonService.Application.Services.Interfaces;
using PersonService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PersonService.Infrastructure.Repositories.Repositories;

public abstract class GenericRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationContext _context;

    protected GenericRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).ToListAsync();
    }

    public async Task<T?> GetWithInclude(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _context.Set<T>().AsQueryable();
        
        foreach (var include in includeProperties)
        {
            query.Include(include);
        }

        return await query.FirstOrDefaultAsync(filter);

    }
    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(filter);
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}