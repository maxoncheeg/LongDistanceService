using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Cargoes;

public class CargoCategory : AbstractNameEntity
{
    public int UnitId { get; set; }
    public Unit Unit { get; set; } = new();
    public IList<VehicleCargoCategory> VehicleCargoCategories { get; set; } = new List<VehicleCargoCategory>();
    public IList<Cargo> Cargoes { get; set; } = new List<Cargo>();
}