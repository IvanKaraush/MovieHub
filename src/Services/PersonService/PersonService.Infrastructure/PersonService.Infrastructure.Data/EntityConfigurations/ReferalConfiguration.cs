using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonService.Infrastructure.Data.EntityConfigurations;

public class ReferalConfiguration : IEntityTypeConfiguration<Referal>
{
    public void Configure(EntityTypeBuilder<Referal> builder)
    {
        builder.ToTable("referals")
            .HasKey(c => c.Id);

        builder.Property(c => c.ReferalId)
            .HasColumnName("referal_id")
            .IsRequired();

        builder.Property(c => c.ReferalName)
            .HasColumnName("referal_name")
            .IsRequired();

        builder.Property(c => c.Income)
            .HasColumnName("income");

        builder.Property(c => c.PersonName)
            .HasColumnName("person_name")
            .IsRequired();

        builder.Property(c => c.ReferalName)
            .HasColumnName("referal_name")
            .IsRequired();
    }
}