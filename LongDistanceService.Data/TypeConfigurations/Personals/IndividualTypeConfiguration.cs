using LongDistanceService.Domain.Entities.Personals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Personals;

public class IndividualTypeConfiguration : IEntityTypeConfiguration<Individual>
{
    public void Configure(EntityTypeBuilder<Individual> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(32).IsRequired().HasColumnName("name");
        builder.Property(p => p.Surname).HasMaxLength(32).IsRequired().HasColumnName("surname");
        builder.Property(p => p.Patronymic).HasMaxLength(32).IsRequired().HasColumnName("patronymic");
        builder.Property(p => p.Phone).HasMaxLength(18).IsRequired().HasColumnName("phone");
        builder.Property(p => p.PassportDate).HasMaxLength(10).IsRequired().HasColumnName("passport_date");
        builder.Property(p => p.PassportIssued).HasMaxLength(64).IsRequired().HasColumnName("passport_issued");
        builder.Property(p => p.PassportSeries).HasMaxLength(10).IsRequired().HasColumnName("passport_series");
        builder.Property(p => p.Id).HasColumnName("id");

        builder.ToTable("individuals").HasKey(p => p.Id);
        builder.HasAlternateKey(p => p.PassportSeries);
    }
}