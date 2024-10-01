using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Vehicles;

namespace LongDistanceService.Domain.Entities.Cargos;

public class CargoCategory : AbstractNameEntity
{
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    public IList<Vehicle> Vehicles { get; set; }
}