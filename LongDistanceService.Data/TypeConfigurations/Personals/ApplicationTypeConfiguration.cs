using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Data.Entities.Personals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Personals;

public class ApplicationTypeConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.Property(p => p.Created).HasColumnName("created");
        builder.Property(p => p.Status).HasConversion<int>().HasColumnName("status");
        builder.Property(p => p.CreatorId).HasColumnName("creator_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("applications").HasKey(p => p.Id);

        builder.HasMany(p => p.Messages).WithOne(p => p.Application)
            .HasForeignKey(p => p.ApplicationId);
        builder.HasOne(p => p.User).WithMany(p => p.Applications)
            .HasForeignKey(p => p.CreatorId);
    }
}