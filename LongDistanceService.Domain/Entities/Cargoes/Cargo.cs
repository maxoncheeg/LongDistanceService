using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Cargoes;

public class Cargo : AbstractNameEntity
{
    public int CategoryId { get; set; }
    public CargoCategory Category { get; set; } = new();

    public IList<OrderCargo> OrderCargoes { get; set; } = new List<OrderCargo>();
}