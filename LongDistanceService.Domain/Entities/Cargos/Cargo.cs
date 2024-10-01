using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Cargos;

public class Cargo : AbstractNameEntity
{
    public int CategoryId { get; set; }
    public CargoCategory Category { get; set; }
    public float Amount { get; set; }
    public float Weight { get; set; }
    public float Price { get; set; }
}