﻿using LongDistanceService.Domain.Entities.Personals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Personals;

public class LegalTypeConfiguration : IEntityTypeConfiguration<Legal>
{
    public void Configure(EntityTypeBuilder<Legal> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(32).IsRequired().HasColumnName("name");
        builder.Property(p => p.Surname).HasMaxLength(32).IsRequired().HasColumnName("surname");
        builder.Property(p => p.Patronymic).HasMaxLength(32).IsRequired().HasColumnName("patronymic");
        builder.Property(p => p.Phone).HasMaxLength(18).IsRequired().HasColumnName("phone");
        builder.Property(p => p.TIN).HasMaxLength(10).IsRequired().HasColumnName("tin");
        builder.Property(p => p.CompanyName).HasMaxLength(10).IsRequired().HasColumnName("company_name");
        builder.Property(p => p.BankAccount).HasMaxLength(32).IsRequired().HasColumnName("bank_account");
        builder.Property(p => p.HouseNumber).HasMaxLength(32).IsRequired().HasColumnName("house_number");
        builder.Property(p => p.BankId).HasColumnName("bank_id");
        builder.Property(p => p.StreetId).HasColumnName("street_id");
        builder.Property(p => p.CityId).HasColumnName("city_id");
        builder.Property(p => p.Id).HasColumnName("id");

        builder.ToTable("legals").HasKey(p => p.Id);
        builder.HasAlternateKey(p => p.TIN);
        builder.HasAlternateKey(p => new { p.BankId, p.BankAccount });
    }
}