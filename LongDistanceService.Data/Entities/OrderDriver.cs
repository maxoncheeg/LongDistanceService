using LongDistanceService.Data.Entities.Drivers;

namespace LongDistanceService.Data.Entities;

public class OrderDriver
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = new();
    public int DriverId { get; set; }
    public Driver Driver { get; set; } = new();
}