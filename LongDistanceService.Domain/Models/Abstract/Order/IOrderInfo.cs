using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface IOrderInfo
{
    public int Id { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Vehicle { get; set; }
    public string ImagePath { get; set; }
    public OrderState State { get; set; }
    public int DriversAmount { get; set; }
}