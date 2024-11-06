using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Cargos;
using LongDistanceService.Domain.Entities.Vehicles;

namespace LongDistanceService.Domain.Entities;

public class VehicleCargoCategory : IEntity
{
    public int Id { get; set; }
    public int CargoCategoryId { get; set; }
    public int VehicleId { get; set; }
    
    public CargoCategory Category { get; set; }
    public Vehicle Vehicle { get; set; }
}