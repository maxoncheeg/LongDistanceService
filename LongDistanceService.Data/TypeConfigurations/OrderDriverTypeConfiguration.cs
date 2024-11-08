using LongDistanceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations;

public class OrderDriverTypeConfiguration : IEntityTypeConfiguration<OrderDriver>
{
    public void Configure(EntityTypeBuilder<OrderDriver> builder)
    {
        builder.Property(p => p.DriverId).HasColumnName("driver_id");
        builder.Property(p => p.OrderId).HasColumnName("order_id");

        builder.ToTable("order_drivers").HasKey(k => new { k.DriverId, k.OrderId });

        builder.HasOne(p => p.Driver)
            .WithMany(p => p.OrderDrivers).HasForeignKey(p => p.DriverId);
        builder.HasOne(p => p.Order)
            .WithMany(p => p.OrderDrivers).HasForeignKey(p => p.OrderId);
    }
}