﻿using LongDistanceService.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Identity;

public class MenuTabRightConfiguration : IEntityTypeConfiguration<MenuTabRight>
{
    public void Configure(EntityTypeBuilder<MenuTabRight> builder)
    {
        builder.Property(p => p.R).HasColumnName("r").HasDefaultValue(false);
        builder.Property(p => p.W).HasColumnName("w").HasDefaultValue(false);
        builder.Property(p => p.E).HasColumnName("e").HasDefaultValue(false);
        builder.Property(p => p.D).HasColumnName("d").HasDefaultValue(false);
        builder.Property(p => p.MenuTabId).HasColumnName("tab_id");
        builder.Property(p => p.UserId).HasColumnName("user_id");

        builder.ToTable("menu_tab_rights").HasKey(p => new { p.UserId, p.MenuTabId });

        builder.HasOne(p => p.MenuTab).WithMany(p => p.Rights).HasForeignKey(p => p.MenuTabId);
        builder.HasOne(p => p.User).WithMany(p => p.Rights).HasForeignKey(p => p.UserId);
    }
}