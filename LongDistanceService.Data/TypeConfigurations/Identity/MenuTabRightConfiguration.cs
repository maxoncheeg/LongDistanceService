using LongDistanceService.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Identity;

public class MenuTabRightConfiguration : IEntityTypeConfiguration<MenuTabRight>
{
    public void Configure(EntityTypeBuilder<MenuTabRight> builder)
    {
        builder.Property(p => p.R).HasColumnName("r");
        builder.Property(p => p.W).HasColumnName("w");
        builder.Property(p => p.E).HasColumnName("e");
        builder.Property(p => p.D).HasColumnName("d");
        builder.Property(p => p.MenuTabId).HasColumnName("tab_id");
        builder.Property(p => p.UserId).HasColumnName("id");

        builder.ToTable("menu_tab_rights").HasKey(p => new { p.UserId, p.MenuTabId });
    }
}