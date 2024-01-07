using FilmService.Domain.Entities;
using FilmService.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FilmService.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Film> Films { get; set; } = null!;

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public async Task MigrateAsync()
    {
        await Database.MigrateAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FilmConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}