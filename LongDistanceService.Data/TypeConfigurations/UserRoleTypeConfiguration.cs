using LongDistanceService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations;

public class UserRoleTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.RoleId).HasColumnName("role_id");

        builder.ToTable("user_roles").HasKey(k => new { k.UserId, k.RoleId });

        builder.HasOne(p => p.User)
            .WithMany(p => p.UserRoles).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.Role)
            .WithMany(p => p.UserRoles).HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.NoAction);
    }
}