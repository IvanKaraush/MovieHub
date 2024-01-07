using FilmService.Application.Services;
using FilmService.Infrastructure.Data;
using FilmService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureContext(builder.Configuration);

var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<ApplicationContext>().MigrateAsync();
});

app.Run();