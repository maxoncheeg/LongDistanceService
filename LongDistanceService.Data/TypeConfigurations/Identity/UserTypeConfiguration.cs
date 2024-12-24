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
        builder.Property(p => p.Name).HasMaxLength(32).HasColumnName("name");
        builder.Property(p => p.Surname).HasMaxLength(32).HasColumnName("surname");
        builder.Property(p => p.RoleId).HasColumnName("role_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("users").HasKey(p => p.Id);
        
        builder.HasOne(p => p.Role).WithMany(p => p.Users).HasForeignKey(p => p.RoleId);

        builder.HasIndex(p => p.Login).IsUnique();
    }
}