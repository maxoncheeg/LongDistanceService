using LongDistanceService.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Identity;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(p => p.Login).HasColumnName("login");
        builder.Property(p => p.Password).HasColumnName("password");
        builder.Property(p => p.IsEmailVerified).HasColumnName("is_email_verified").HasDefaultValue(false);
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("users").HasKey(p => p.Id);

        builder.HasIndex(p => p.Login).IsUnique();
    }
}