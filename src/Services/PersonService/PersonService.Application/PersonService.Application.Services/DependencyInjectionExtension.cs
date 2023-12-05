using Microsoft.Extensions.DependencyInjection;
using PersonService.Application.Services.Interfaces;
using PersonService.Application.Services.Mappers;

namespace PersonService.Application.Services;

public static class DependencyInjectionExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonService, Services.PersonService>();
        services.AddScoped<IReferalService, Services.ReferalService>();
        services.AddAutoMapper(typeof(MappingPersonProfile));
    }
}