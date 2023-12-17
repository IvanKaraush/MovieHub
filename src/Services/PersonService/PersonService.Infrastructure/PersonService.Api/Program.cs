using System.Reflection;
using PersonService.Api.Converters;
using PersonService.Api.Mapping;
using PersonService.Application.Services;
using PersonService.Infrastructure.Repositories;
using ExceptionsLibrary.Interfaces;
using ExceptionsLibrary.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PersonService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter()));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7008";
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TestApi", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("TestApi", "PersonServiceAPI");
    });
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PersonService.Api",
        Version = "v1",
    });
});

builder.Services.ConfigureContext(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();
builder.Services.AddSingleton<IGlobalExceptionMapper, GlobalExceptionMapper>();


var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyBuilder =>
{
    policyBuilder.AllowAnyOrigin();
    policyBuilder.AllowAnyHeader();
    policyBuilder.AllowAnyMethod();
});

app.UseAuthentication();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<ApplicationContext>().MigrateAsync();
});

app.Run();