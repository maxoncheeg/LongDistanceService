using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Addresses;
using LongDistanceService.Domain.Entities.Cargos;
using LongDistanceService.Domain.Entities.Drivers;
using LongDistanceService.Domain.Entities.Enums;
using LongDistanceService.Domain.Entities.Vehicles;

namespace LongDistanceService.Domain.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    
    public int ReceiverId { get; set; }
    public ClientTypes ReceiverType { get; set; }
    public int SenderId { get; set; }
    public ClientTypes SenderType { get; set; }
    
    public int SendCityId { get; set; }
    public int SendStreetId { get; set; }
    public int SendHouseNumber { get; set; }
    public City SendCity { get; set; }
    public Street SendStreet { get; set; }
    
    public int ReceiveCityId { get; set; }
    public int ReceiveStreetId { get; set; }
    public int ReceiveHouseNumber { get; set; }
    public City ReceiveCity { get; set; }
    public Street ReceiveStreet { get; set; }
    
    public string State { get; set; }
    public decimal RouteLength { get; set; }
    public DateTime LoadingDate { get; set; }
    
    public virtual IList<Driver> Drivers { get; set; }
    public virtual IList<Cargo> Cargoes { get; set; } //??
    public virtual IList<OrderCargo> OrderCargoes { get; set; }
}