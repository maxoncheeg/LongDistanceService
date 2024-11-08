using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Drivers;

namespace LongDistanceService.Domain.Entities;

public class OrderDriver
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = new();
    public int DriverId { get; set; }
    public Driver Driver { get; set; } = new();
}