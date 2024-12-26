using LongDistanceService.Data.Entities.Cargoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Cargoes;

public class CargoTypeConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(64).IsRequired().HasColumnName("name");
        builder.Property(p => p.CategoryId).HasColumnName("category_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
        
        builder.HasIndex(p => p.Name).IsUnique();

        builder.ToTable("cargoes").HasKey(p => p.Id);
    }
}