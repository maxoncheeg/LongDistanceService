using LongDistanceService.Data.Entities.Cargoes;
using LongDistanceService.Data.Entities.Vehicles;

namespace LongDistanceService.Data.Entities;

public class VehicleCargoCategory
{
    public int CargoCategoryId { get; set; }
    public int VehicleId { get; set; }
    
    public CargoCategory Category { get; set; } = new();
    public Vehicle Vehicle { get; set; } = new();
}