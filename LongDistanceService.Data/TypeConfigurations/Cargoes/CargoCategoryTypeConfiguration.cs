using LongDistanceService.Data.Entities.Cargoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Cargoes;

public class CargoCategoryTypeConfiguration : IEntityTypeConfiguration<CargoCategory>
{
    public void Configure(EntityTypeBuilder<CargoCategory> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(64).IsRequired().HasColumnName("name");
        builder.Property(p => p.UnitId).HasColumnName("unit_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
        
        builder.ToTable("cargo_categories").HasKey(p => p.Id);
        
        builder.HasIndex(p => p.Name).IsUnique();
        
        builder.HasMany(p => p.Cargoes)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
    }
}