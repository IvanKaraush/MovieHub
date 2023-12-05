using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PersonService.Infrastructure.Data;

public static class DependencyInjectionExtension
{
    public static void ConfigureContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNpgsql<ApplicationContext>(configuration.GetConnectionString("DefaultConnection"));
    }
}