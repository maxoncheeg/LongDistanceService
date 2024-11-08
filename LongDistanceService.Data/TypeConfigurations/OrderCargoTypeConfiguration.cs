using LongDistanceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations;

public class OrderCargoTypeConfiguration : IEntityTypeConfiguration<OrderCargo>
{
    public void Configure(EntityTypeBuilder<OrderCargo> builder)
    {
        builder.Property(p => p.Amount).HasPrecision(9,3).HasColumnName("amount");
        builder.Property(p => p.Weight).HasPrecision(9,3).HasColumnName("weight");
        builder.Property(p => p.Price).HasPrecision(14,2).HasColumnName("price");
        
        builder.Property(p => p.CargoId).HasColumnName("cargo_id");
        builder.Property(p => p.OrderId).HasColumnName("order_id");

        builder.ToTable("order_cargoes", t =>
        {
            t.HasCheckConstraint("CK_amount", "amount > 0");
            t.HasCheckConstraint("CK_weight", "weight > 0");
            t.HasCheckConstraint("CK_price", "price > 0");
        }).HasKey(k => new { k.CargoId, k.OrderId });

        builder.HasOne(p => p.Cargo)
            .WithMany(p => p.OrderCargoes).HasForeignKey(p => p.CargoId);
        builder.HasOne(p => p.Order)
            .WithMany(p => p.OrderCargoes).HasForeignKey(p => p.OrderId);
    }
}