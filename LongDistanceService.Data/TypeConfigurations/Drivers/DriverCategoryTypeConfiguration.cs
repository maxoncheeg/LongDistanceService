﻿using LongDistanceService.Domain.Entities.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Drivers;

public class DriverCategoryTypeConfiguration : IEntityTypeConfiguration<DriverCategory>
{
    public void Configure(EntityTypeBuilder<DriverCategory> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(4).IsRequired().HasColumnName("name");
        builder.Property(p => p.Id).HasColumnName("id");
        
        builder.ToTable("driver_categories").HasKey(p => p.Id);
        
        builder.HasMany(p => p.Drivers)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
    }
}