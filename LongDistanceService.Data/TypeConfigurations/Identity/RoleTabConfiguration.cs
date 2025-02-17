using LongDistanceService.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Identity;

public class RoleTabConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(p => p.Type).HasConversion<int>().HasColumnName("type");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("roles").HasKey(p => p.Id);

        builder.HasIndex(p => p.Type).IsUnique();
    }
}