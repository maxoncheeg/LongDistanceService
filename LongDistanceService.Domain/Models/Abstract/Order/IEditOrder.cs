using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface IEditOrder
{
    public int Id { get; set; }
    public int VehicleId { get; set; }

    public int ReceiverId { get; set; }
    public ClientTypes ReceiverType { get; set; }
    public int SenderId { get; set; }
    public ClientTypes SenderType { get; set; }

    public int SendCityId { get; set; }
    public int SendStreetId { get; set; }
    public string SendHouseNumber { get; set; }

    public int ReceiveCityId { get; set; }
    public int ReceiveStreetId { get; set; }
    public string ReceiveHouseNumber { get; set; }

    public OrderState State { get; set; }
    public decimal RouteLength { get; set; }
    public DateTime? LoadingDate { get; set; }

    public IOrderCargo[] Cargoes { get; set; }
    public int[] DriverIds { get; set; }
}