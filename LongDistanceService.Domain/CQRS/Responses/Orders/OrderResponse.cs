using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Addresses;
using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Drivers;
using LongDistanceService.Domain.Models.Abstract.Order;
using LongDistanceService.Domain.Models.Abstract.Personals;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.CQRS.Responses.Orders;

public class OrderResponse : IOrder
{
    public int Id { get; set; }
    public IVehicle Vehicle { get; set; } = null!;
    public int ReceiverId { get; set; }
    public ClientTypes ReceiverType { get; set; }
    public int SenderId { get; set; }
    public ClientTypes SenderType { get; set; }
    public string SendHouseNumber { get; set; } = string.Empty;
    public ICity SendCity { get; set; } = null!;
    public IStreet SendStreet { get; set; } = null!;
    public string ReceiveHouseNumber { get; set; } = string.Empty;
    public ICity ReceiveCity { get; set; } = null!;
    public IStreet ReceiveStreet { get; set; } = null!;
    public OrderState State { get; set; }
    public decimal RouteLength { get; set; }
    public DateTime? LoadingDate { get; set; }
    public IList<IOrderCargo> OrderCargoes { get; set; } = [];
    public IList<IDriver> OrderDrivers { get; set; } = [];
    
    public IIndividual? IndividualSender { get; set; }
    public IIndividual? IndividualReceiver { get; set; }
    public ILegal? LegalSender { get; set; }
    public ILegal? LegalReceiver { get; set; }
}