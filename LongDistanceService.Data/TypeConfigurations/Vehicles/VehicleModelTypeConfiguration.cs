﻿using LongDistanceService.Data.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Vehicles;

public class VehicleModelTypeConfiguration : IEntityTypeConfiguration<VehicleModel>
{
    public void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(32).HasColumnName("name");
        builder.Property(p => p.BrandId).HasColumnName("brand_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("vehicle_models").HasKey(k => k.Id);

        builder.HasIndex(p => new { p.BrandId, p.Name }).IsUnique();

        builder.HasMany(p => p.Vehicles)
            .WithOne(p => p.Model)
            .HasForeignKey(p => p.ModelId).OnDelete(DeleteBehavior.NoAction);
    }
}