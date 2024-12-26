using LongDistanceService.Data.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Vehicles;

public class VehicleTypeConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        // properties
        builder.Property(p => p.Kilometerage).HasDefaultValue(0).HasPrecision(9, 2).IsRequired().HasColumnName("kilometerage");
        builder.Property(p => p.Year).HasDefaultValue(1970).IsRequired().HasColumnName("year");
        builder.Property(p => p.OverhaulYear).HasDefaultValue(1970).IsRequired().HasColumnName("overhaul_year");
        builder.Property(p => p.LicensePlate).HasMaxLength(16).IsRequired().HasColumnName("license_plate");
        builder.Property(p => p.ImagePath).HasColumnName("image_path");
        builder.Property(p => p.LoadCapacity).HasColumnName("load_capacity").HasDefaultValue(4);
        builder.Property(p => p.ModelId).HasColumnName("model_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.HasIndex(p => p.LicensePlate).IsUnique();
        // constraints
        
        builder.ToTable("vehicles", 
            t =>
            {
                t.HasCheckConstraint("CK_kilometerage", "kilometerage > 0 OR kilometerage = 0");
            })
            .HasKey(p => p.Id);

        builder.HasMany(p => p.Orders).WithOne(p => p.Vehicle).HasForeignKey(p => p.VehicleId).OnDelete(DeleteBehavior.NoAction);
    }
}