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
        
        builder.Property(p => p.ReceiveCityId).HasColumnName("receive_city_id");
        builder.Property(p => p.ReceiveStreetId).HasColumnName("receive_street_id");
        builder.Property(p => p.SendStreetId).HasColumnName("send_street_id");
        builder.Property(p => p.SendCityId).HasColumnName("send_city_id");
        builder.Property(p => p.VehicleId).HasColumnName("vehicle_id");
        
        
        builder.Property(p => p.IndividualReceiverId).HasColumnName("individual_receiver_id");
        builder.Property(p => p.LegalReceiverId).HasColumnName("legal_receiver_id");
        builder.Property(p => p.IndividualSenderId).HasColumnName("individual_sender_id");
        builder.Property(p => p.LegalSenderId).HasColumnName("legal_sender_id");
        
        builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.ToTable("orders", t =>
        {
            t.HasCheckConstraint("CK_RouteLength", "route_length > 0");
        }).HasKey(p => p.Id);
        
        builder.HasOne(p => p.IndividualReceiver).WithMany(p => p.ReceivedOrders).HasForeignKey(p => p.IndividualReceiverId);
        builder.HasOne(p => p.LegalReceiver).WithMany(p => p.ReceivedOrders).HasForeignKey(p => p.LegalReceiverId);
        builder.HasOne(p => p.IndividualSender).WithMany(p => p.SendedOrders).HasForeignKey(p => p.IndividualSenderId);
        builder.HasOne(p => p.LegalSender).WithMany(p => p.SendedOrders).HasForeignKey(p => p.LegalSenderId);
    }
}