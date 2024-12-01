using LongDistanceService.Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Addresses;

public class CityTypeConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(32).IsRequired().HasColumnName("name");
        builder.Property(p => p.Id).HasColumnName("id");
        
        builder.ToTable("cities").HasKey(p => p.Id);
        
        builder.HasMany(p => p.ReceiveOrders).WithOne(p => p.ReceiveCity).HasForeignKey(p => p.ReceiveCityId);
        builder.HasMany(p => p.SendOrders).WithOne(p => p.SendCity).HasForeignKey(p => p.SendCityId);
        builder.HasMany(p => p.Legals).WithOne(p => p.City).HasForeignKey(p => p.CityId);
    }
}