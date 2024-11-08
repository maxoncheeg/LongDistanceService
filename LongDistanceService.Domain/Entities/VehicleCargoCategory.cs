using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Cargoes;
using LongDistanceService.Domain.Entities.Vehicles;

namespace LongDistanceService.Domain.Entities;

public class VehicleCargoCategory
{
    public int CargoCategoryId { get; set; }
    public int VehicleId { get; set; }
    
    public CargoCategory Category { get; set; } = new();
    public Vehicle Vehicle { get; set; } = new();
}