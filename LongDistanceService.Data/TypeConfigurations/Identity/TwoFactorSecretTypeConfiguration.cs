using LongDistanceService.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Identity;

public class TwoFactorSecretConfiguration : IEntityTypeConfiguration<TwoFactorSecret>
{
    public void Configure(EntityTypeBuilder<TwoFactorSecret> builder)
    {
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Secret).HasColumnName("secret");
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.Expires).HasColumnName("expires");
        builder.Property(p => p.CodeReason).HasConversion<int>().HasColumnName("reason");

        builder.ToTable("two_factor_secrets").HasKey(p => p.Id);

        builder.HasOne(p => p.User).WithMany(u => u.TwoFactorSecrets).HasForeignKey(p => p.UserId);
    }
}