using PersonService.Application.Services.Interfaces;
using PersonService.Infrastructure.Data;

namespace PersonService.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<T> ExecuteInTransactionAsync<T>(Func<Task<T>> action)
    {
        try
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            var result = await action();
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
            return result;
        }
        catch
        {
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }
}