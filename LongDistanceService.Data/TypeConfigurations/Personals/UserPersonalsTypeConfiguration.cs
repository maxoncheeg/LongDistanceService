using LongDistanceService.Data.Entities.Personals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations.Personals;

public class UserPersonalsTypeConfiguration: IEntityTypeConfiguration<UserPersonals>
{
    public void Configure(EntityTypeBuilder<UserPersonals> builder)
    {
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.PersonalId).HasColumnName("personal_id");
        builder.Property(p => p.PersonalType).HasColumnName("personal_type").HasConversion<int>();

        builder.ToTable("user_personals").HasKey(p => p.UserId);
        builder.HasOne(p => p.User).WithOne(p => p.Personals).HasForeignKey<UserPersonals>(up => up.UserId).OnDelete(DeleteBehavior.NoAction);
    }
}