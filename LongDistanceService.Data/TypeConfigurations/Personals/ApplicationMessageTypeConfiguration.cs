using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Data.Entities.Personals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Personals;

public class ApplicationMessageTypeConfiguration : IEntityTypeConfiguration<ApplicationMessage>
{
    public void Configure(EntityTypeBuilder<ApplicationMessage> builder)
    {
        builder.Property(p => p.Timestamp).HasColumnName("timestamp");
        builder.Property(p => p.Text).HasMaxLength(512).HasColumnName("text");
        builder.Property(p => p.AnsweredAt).HasColumnName("answered_at");
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.ApplicationId).HasColumnName("application_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("application_messages").HasKey(p => p.Id);

        builder.HasOne(p => p.User).WithMany(p => p.ApplicationMessages)
            .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.Application).WithMany(p => p.Messages)
            .HasForeignKey(p => p.ApplicationId).OnDelete(DeleteBehavior.NoAction);
    }
}