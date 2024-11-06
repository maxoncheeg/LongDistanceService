using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Cargos;

namespace LongDistanceService.Domain.Entities;

public class OrderCargo : IEntity
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int CargoId { get; set; }
    public Cargo Cargo { get; set; }
    
    public decimal Amount { get; set; }
    public decimal Weight { get; set; }
    public decimal Price { get; set; }
}