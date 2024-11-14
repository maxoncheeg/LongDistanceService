using LongDistanceService.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Identity;

public class MenuTabConfiguration : IEntityTypeConfiguration<MenuTab>
{
    public void Configure(EntityTypeBuilder<MenuTab> builder)
    {
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.DllName).HasColumnName("dll");
        builder.Property(p => p.Order).HasColumnName("order");
        builder.Property(p => p.FunctionName).HasColumnName("function");

        builder.Property(p => p.ParentId).HasColumnName("parent_id");
        builder.Property(p => p.Id).HasColumnName("id");

        builder.ToTable("menu_tabs").HasKey(p => p.Id);
    }
}