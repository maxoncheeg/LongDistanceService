using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Addresses;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface IOrder
{
    public int Id { get; set; }
    public IVehicle Vehicle { get; set; }

    public int ReceiverId { get; set; }
    public ClientTypes ReceiverType { get; set; }
    public int SenderId { get; set; }
    public ClientTypes SenderType { get; set; }
    
    public string SendHouseNumber { get; set; }
    public ICity SendCity { get; set; }
    public IStreet SendStreet { get; set; }
    
    public string ReceiveHouseNumber { get; set; }
    public ICity ReceiveCity { get; set; }
    public IStreet ReceiveStreet { get; set; }

    public OrderState State { get; set; }
    public decimal RouteLength { get; set; }
    public DateTime? LoadingDate { get; set; }

    public IList<IOrderCargo> OrderCargoes { get; set; }
    public IList<IOrderDriver> OrderDrivers { get; set; }
}