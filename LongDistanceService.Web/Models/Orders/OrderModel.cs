using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Order;
using LongDistanceService.Web.Models.Cargoes;

namespace LongDistanceService.Web.Models.Orders;

public class OrderModel : IOrderOnAdd
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int ReceiverId { get; set; }
    public ClientTypes ReceiverType { get; set; }
    public int SenderId { get; set; }
    public ClientTypes SenderType { get; set; }
    public int SendCityId { get; set; }
    public int SendStreetId { get; set; }
    [Required]
    public string SendHouseNumber { get; set; } = string.Empty;
    public int ReceiveCityId { get; set; }
    public int ReceiveStreetId { get; set; }
    [Required]
    public string ReceiveHouseNumber { get; set; } = string.Empty;
    public OrderState State { get; set; } = OrderState.Loading;
    [Required, Range(0, 4000, ErrorMessage = "От 0 до 10000 км")]
    public decimal RouteLength { get; set; }
    public DateTime LoadingDate { get; set; }
    public IList<IOrderCargoOnAdd> Cargoes { get; set; } = [];
    public int[] Drivers { get; set; } = [];
    public OrderCargoModel CargoModel { get; set; } = new();
}