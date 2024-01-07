using FilmService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmService.Infrastructure.Data.EntityConfigurations;

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.ToTable("films");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Description)
            .HasColumnName("description")
            .IsRequired();

        builder.Property(c => c.Title)
            .HasColumnName("title")
            .IsRequired();

        builder.Property(c => c.Url)
            .HasColumnName("url")
            .IsRequired();
    }
}