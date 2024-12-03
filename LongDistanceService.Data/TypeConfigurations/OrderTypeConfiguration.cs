using LongDistanceService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LongDistanceService.Data.TypeConfigurations;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(p => p.SendHouseNumber).IsRequired().HasColumnName("send_house");
        builder.Property(p => p.ReceiveHouseNumber).IsRequired().HasColumnName("receive_house");
        builder.Property(p => p.RouteLength).HasPrecision(9, 2).IsRequired().HasColumnName("route_length");
        builder.Property(p => p.LoadingDate).HasColumnName("loading_date");

        builder.Property(p => p.State).HasConversion<int>().HasColumnName("state");
        builder.Property(p => p.SenderType).HasConversion<int>().HasColumnName("receiver_type");
        builder.Property(p => p.ReceiverType).HasConversion<int>().HasColumnName("sender_type");
        
        builder.Property(p => p.ReceiveCityId).HasColumnName("receive_city_id");
        builder.Property(p => p.ReceiveStreetId).HasColumnName("receive_street_id");
        builder.Property(p => p.SendStreetId).HasColumnName("send_street_id");
        builder.Property(p => p.SendCityId).HasColumnName("send_city_id");
        builder.Property(p => p.ReceiverId).HasColumnName("receiver_id");
        builder.Property(p => p.SenderId).HasColumnName("sender_id");
        builder.Property(p => p.VehicleId).HasColumnName("vehicle_id");
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("orders", t =>
        {
            t.HasCheckConstraint("CK_RouteLength", "route_length > 0");
        }).HasKey(p => p.Id);
    }
}