using LongDistanceService.Domain.Models.Abstract.Drivers;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface IOrderDriver
{
    public IDriver Driver { get; set; }
    public IOrder Order { get; set; }
}