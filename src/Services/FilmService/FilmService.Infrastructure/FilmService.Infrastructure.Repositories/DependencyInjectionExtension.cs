using FilmService.Application.Services.Interfaces;
using FilmService.Infrastructure.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FilmService.Infrastructure.Repositories;

public static class DependencyInjectionExtension
{
    public static void ConfigureRepositories(this IServiceCollection service)
    {
        service.AddScoped<IFilmRepository, FilmRepository>();
    }
}