using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PersonService.Infrastructure.Data.EntityConfigurations;

namespace PersonService.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public async Task MigrateAsync()
        {
            await Database.MigrateAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ReferralConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}