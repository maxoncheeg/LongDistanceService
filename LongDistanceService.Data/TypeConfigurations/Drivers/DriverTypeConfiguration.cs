using LongDistanceService.Data.Entities.Drivers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Drivers;

public class DriverTypeConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.Property(p => p.EmployeeNumber).HasMaxLength(8).HasColumnName("employee_number");
        builder.Property(p => p.Class).HasDefaultValue(0).IsRequired().HasColumnName("class");
        builder.Property(p => p.Name).HasMaxLength(32).IsRequired().HasColumnName("name");
        builder.Property(p => p.Surname).HasMaxLength(32).IsRequired().HasColumnName("surname");
        builder.Property(p => p.Patronymic).HasMaxLength(32).IsRequired().HasColumnName("patronymic");
        builder.Property(p => p.BirthYear).HasDefaultValue(2004).IsRequired().HasColumnName("birth_year");
        builder.Property(p => p.Experience).HasDefaultValue(0).IsRequired().HasColumnName("experience");
        builder.Property(p => p.CategoryId).HasColumnName("category_id");
        builder.Property(p => p.Id).HasColumnName("id");
        
        builder.ToTable("drivers", t =>
        {
            t.HasCheckConstraint("CK_experience", "experience > 0 OR experience = 0");
        }).HasKey(p => p.Id);

        builder.HasAlternateKey(p => p.EmployeeNumber);
    }
}