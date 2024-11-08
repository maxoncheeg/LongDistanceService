using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Cargoes;

namespace LongDistanceService.Domain.Entities;

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