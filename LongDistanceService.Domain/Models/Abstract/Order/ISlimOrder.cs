using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Personals;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface ISlimOrder
{
    public int Id { get; set; }
    public IVehicleInfo Vehicle { get; set; }

    public ClientTypes ReceiverType { get; set; }
    public ClientTypes SenderType { get; set; }
    public int ReceiverId { get; }
    public int SenderId { get; }
    public string ReceiverName { get; }
    public string SenderName { get; }

    public string SendAddress { get; set; }
    public string ReceiveAddress { get; set; }

    public OrderState State { get; set; }
    public decimal RouteLength { get; set; }
    public DateTime? LoadingDate { get; set; }
}