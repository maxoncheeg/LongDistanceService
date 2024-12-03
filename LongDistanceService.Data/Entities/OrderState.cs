using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities;

public class OrdersState : IEntity
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string State { get; set; } = string.Empty;
}