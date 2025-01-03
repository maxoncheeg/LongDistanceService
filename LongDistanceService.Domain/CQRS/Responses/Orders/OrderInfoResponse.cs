using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Order;

namespace LongDistanceService.Domain.CQRS.Responses.Orders;

public class OrderInfoResponse : IOrderInfo
{
    public int Id { get; set; }
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public string Vehicle { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public OrderState State { get; set; }
    public int DriversAmount { get; set; }
}