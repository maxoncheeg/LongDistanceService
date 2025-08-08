using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Data.Entities.Addresses;
using LongDistanceService.Data.Entities.Personals;
using LongDistanceService.Data.Entities.Vehicles;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Data.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = new();

    public int? IndividualReceiverId { get; set; }
    public int? LegalReceiverId { get; set; }
    public int? IndividualSenderId { get; set; }
    public int? LegalSenderId { get; set; }

    public int SendCityId { get; set; }
    public int SendStreetId { get; set; }
    public string SendHouseNumber { get; set; } = String.Empty;
    public City SendCity { get; set; } = new();
    public Street SendStreet { get; set; } = new();

    public int ReceiveCityId { get; set; }
    public int ReceiveStreetId { get; set; }
    public string ReceiveHouseNumber { get; set; } = String.Empty;
    public City ReceiveCity { get; set; } = new();
    public Street ReceiveStreet { get; set; } = new();

    public OrderState State { get; set; }
    public decimal RouteLength { get; set; }
    public DateTime? LoadingDate { get; set; }

    public IList<OrderCargo> OrderCargoes { get; set; } = new List<OrderCargo>();
    public IList<OrderDriver> OrderDrivers { get; set; } = new List<OrderDriver>();

    public Individual? IndividualReceiver { get; set; }
    public Individual? IndividualSender { get; set; }
    public Legal? LegalReceiver { get; set; }
    public Legal? LegalSender { get; set; }
}