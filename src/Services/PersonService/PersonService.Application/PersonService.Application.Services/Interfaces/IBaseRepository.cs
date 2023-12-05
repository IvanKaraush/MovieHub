using System.Linq.Expressions;

namespace PersonService.Application.Services.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetWithInclude(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        Task<T?> GetByIdAsync(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}