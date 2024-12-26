using LongDistanceService.Data.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Addresses;

public class StreetTypeConfiguration : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(32).IsRequired().HasColumnName("name");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
        
        builder.ToTable("streets").HasKey(p => p.Id);

        builder.HasIndex(p => p.Name).IsUnique();
        
        builder.HasMany(p => p.ReceiveOrders).WithOne(p => p.ReceiveStreet).HasForeignKey(p => p.ReceiveStreetId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.SendOrders).WithOne(p => p.SendStreet).HasForeignKey(p => p.SendStreetId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.Legals).WithOne(p => p.Street).HasForeignKey(p => p.StreetId).OnDelete(DeleteBehavior.NoAction);
    }
}