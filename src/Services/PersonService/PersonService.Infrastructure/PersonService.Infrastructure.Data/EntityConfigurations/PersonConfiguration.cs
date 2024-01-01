using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonService.Infrastructure.Data.EntityConfigurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("persons")
            .HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(c => c.Balance)
            .HasColumnName("balance");

        builder.OwnsOne(c => c.ProfileCreationDate, created =>
        {
            created.Property(c => c.CreationDate)
                .HasColumnType("date")
                .HasColumnName("profile_created_date")
                .IsRequired();
        });

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .IsRequired();

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(c => c.Password)
            .HasColumnName("password")
            .IsRequired();

        builder.Property(c => c.WalletName)
            .HasColumnName("wallet_name")
            .IsRequired(false);

        builder.HasMany(c => c.Referals)
            .WithOne()
            .HasForeignKey(c => c.ReferalId)
            .IsRequired();
    }
}