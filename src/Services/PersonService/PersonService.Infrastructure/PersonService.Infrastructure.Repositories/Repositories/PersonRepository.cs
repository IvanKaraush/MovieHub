using PersonService.Application.Services.Interfaces;
using PersonService.Infrastructure.Data;
using Domain.Entities;

namespace PersonService.Infrastructure.Repositories.Repositories;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(ApplicationContext context) : base(context)
    {
    }
}