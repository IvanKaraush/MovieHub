namespace PersonService.Application.Services.Interfaces
{
    public interface IUnitOfWork
    {
        Task ExecuteInTransactionAsync(Func<Task> action);
        Task SaveChangesAsync();
    }
}