using FilmService.Application.Services.Interfaces;
using FilmService.Application.Services.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace FilmService.Application.Services;

public static class DependencyInjectionExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IFilmService, Services.FilmService>();
        services.AddAutoMapper(typeof(MappingFilmProfile));
    }
}