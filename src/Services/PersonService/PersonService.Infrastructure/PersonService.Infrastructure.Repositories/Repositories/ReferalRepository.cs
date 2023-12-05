using PersonService.Application.Services.Interfaces;
using PersonService.Infrastructure.Data;
using Domain.Entities;

namespace PersonService.Infrastructure.Repositories.Repositories;

public class ReferalRepository : GenericRepository<Referal>, IReferalRepository
{
    public ReferalRepository(ApplicationContext context) : base(context)
    {
    }
}