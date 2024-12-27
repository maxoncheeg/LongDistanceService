using LongDistanceService.Domain.Models.Abstract.Drivers;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface IOrderDriver
{
    public IDriver Driver { get; }
    public IOrder Order { get; }
}