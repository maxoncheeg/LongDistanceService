﻿using LongDistanceService.Domain.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Vehicles;

public class VehicleBrandTypeConfiguration : IEntityTypeConfiguration<VehicleBrand>
{
    public void Configure(EntityTypeBuilder<VehicleBrand> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(32).HasColumnName("name");
        builder.Property(p => p.Id).HasColumnName("id");
        
        builder.ToTable("vehicle_brands")
            .HasKey(k => k.Id);
        
        builder.HasMany(p => p.Models)
            .WithOne(p => p.Brand).HasForeignKey(p => p.BrandId);
    }
}