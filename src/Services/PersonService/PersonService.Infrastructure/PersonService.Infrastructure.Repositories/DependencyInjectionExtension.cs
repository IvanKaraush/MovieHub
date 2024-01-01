using PersonService.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PersonService.Infrastructure.Repositories.Repositories;

namespace PersonService.Infrastructure.Repositories;

public static class DependencyInjectionExtension
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}