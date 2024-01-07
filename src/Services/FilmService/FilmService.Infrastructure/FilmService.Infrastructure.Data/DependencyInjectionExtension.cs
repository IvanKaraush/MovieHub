using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmService.Infrastructure.Data;

public static class DependencyInjectionExtension
{
    public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<ApplicationContext>(configuration.GetConnectionString("DefaultConnection"));
    }
}