using LongDistanceService.Data.Entities.Personals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Personals;

public class BankTypeConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(32).HasColumnName("name");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("banks").HasKey(p => p.Id);

        builder.HasIndex(p => p.Name).IsUnique();

        builder.HasMany(p => p.Legals).WithOne(p => p.Bank).HasForeignKey(p => p.BankId).OnDelete(DeleteBehavior.NoAction);
    }
}