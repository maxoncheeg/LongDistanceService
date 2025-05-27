using LongDistanceService.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Identity;

public class AuthProviderTypeConfiguration : IEntityTypeConfiguration<AuthProvider>
{
    public void Configure(EntityTypeBuilder<AuthProvider> builder)
    {
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.ProviderId).HasColumnName("provider_id");
        builder.Property(p => p.ProviderName).HasColumnName("provider_name");

        builder.ToTable("auth_providers").HasKey(p => new
        {
            p.UserId, p.ProviderName
        });
        
        builder.HasOne(p => p.User).WithMany(p => p.AuthProviders).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
    }
}