using System.Linq.Expressions;

namespace PersonService.Application.Services.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    Task<T?> GetWithInclude(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
    Task<T?> GetByIdAsync(object id);
    void Add(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}