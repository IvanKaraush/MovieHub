using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonService.Infrastructure.Data.EntityConfigurations;

public class ReferralConfiguration : IEntityTypeConfiguration<Referral>
{
    public void Configure(EntityTypeBuilder<Referral> builder)
    {
        builder.ToTable("referrals")
            .HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(c => c.ReferralId)
            .HasColumnName("referral_id")
            .IsRequired();

        builder.Property(c => c.ReferralName)
            .HasColumnName("referral_name")
            .IsRequired();

        builder.Property(c => c.Income)
            .HasColumnName("income");

        builder.Property(c => c.PersonName)
            .HasColumnName("person_name")
            .IsRequired();

        builder.Property(c => c.ReferralName)
            .HasColumnName("referral_name")
            .IsRequired();
    }
}