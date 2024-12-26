using LongDistanceService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations;

public class VehicleCargoCategoryTypeConfiguration : IEntityTypeConfiguration<VehicleCargoCategory>
{
    public void Configure(EntityTypeBuilder<VehicleCargoCategory> builder)
    {
        builder.Property(p => p.CargoCategoryId).HasColumnName("cargo_category_id");
        builder.Property(p => p.VehicleId).HasColumnName("vehicle_id");

        builder.ToTable("vehicle_cargo_categories").HasKey(k => new { k.VehicleId, k.CargoCategoryId });

        builder.HasOne(p => p.Vehicle)
            .WithMany(p => p.VehicleCargoCategories).HasForeignKey(p => p.VehicleId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.Category)
            .WithMany(p => p.VehicleCargoCategories).HasForeignKey(p => p.CargoCategoryId).OnDelete(DeleteBehavior.NoAction);
    }
}