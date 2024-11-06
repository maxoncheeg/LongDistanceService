using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Vehicles;

namespace LongDistanceService.Domain.Entities.Cargos;

public class Cargo : AbstractNameEntity
{
    public int CategoryId { get; set; }
    public CargoCategory Category { get; set; }
    public virtual IList<Vehicle> Vehicles { get; set; }
}