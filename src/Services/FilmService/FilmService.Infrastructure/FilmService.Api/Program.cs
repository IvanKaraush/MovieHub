using ExceptionsLibrary.Interfaces;
using ExceptionsLibrary.Middleware;
using FilmService.Api.Mappers;
using FilmService.Application.Services;
using FilmService.Infrastructure.Data;
using FilmService.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FilmService.Api",
        Version = "v1",
    });
});

builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureContext(builder.Configuration);
builder.Services.AddSingleton<IGlobalExceptionMapper, GlobalExceptionMapper>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<ApplicationContext>().MigrateAsync();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();