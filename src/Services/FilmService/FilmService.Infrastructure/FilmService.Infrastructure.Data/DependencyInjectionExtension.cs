using Microsoft.Extensions.DependencyInjection;

namespace FilmService.Infrastructure.Data;

public static class DependencyInjectionExtension
{
    public static void ConfigureContext(this IServiceCollection services)
    {
        services.AddNpgsql<ApplicationContext>("Server=localhost;Port=5433;DataBase=Persons;User Id=postgres;Password=134204");
    }
}