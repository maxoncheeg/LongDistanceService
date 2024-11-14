using LongDistanceService.Data.Entities.Cargoes;

namespace LongDistanceService.Data.Entities;

public class OrderCargo
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = new();
    public int CargoId { get; set; }
    public Cargo Cargo { get; set; } = new();
    
    public decimal Amount { get; set; }
    public decimal Weight { get; set; }
    public decimal Price { get; set; }
}