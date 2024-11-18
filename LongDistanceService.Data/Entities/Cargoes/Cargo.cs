using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Cargoes;

public class Cargo : AbstractNameEntity
{
    public int CategoryId { get; set; }
    public CargoCategory Category { get; set; } = new();

    public IList<OrderCargo> OrderCargoes { get; set; } = new List<OrderCargo>();
}