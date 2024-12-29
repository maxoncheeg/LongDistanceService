using LongDistanceService.Domain.Models.Abstract.Drivers;
using LongDistanceService.Domain.Models.Abstract.Order;

namespace LongDistanceService.Domain.CQRS.Responses.Orders;

public class OrderDriverResponse : IOrderDriver
{
    public IDriver Driver { get; set; } = null!;
    public IOrder Order { get; set; }
}