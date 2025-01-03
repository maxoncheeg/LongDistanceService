﻿using LongDistanceService.Data.Entities.Cargoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Cargoes;

public class UnitTypeConfiguration : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        // properties
        builder.Property(p => p.Name).HasMaxLength(32).IsRequired().HasColumnName("name");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        //constraints
        builder.ToTable("units").HasKey(p => p.Id);
        
        builder.HasIndex(p => p.Name).IsUnique();

        builder.HasMany(p => p.CargoCategories).WithOne(p => p.Unit).HasForeignKey(p => p.UnitId).OnDelete(DeleteBehavior.NoAction);
    }
}