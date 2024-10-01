using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Cargos;

namespace LongDistanceService.Domain.Entities.Vehicles;

public class Vehicle : IEntity
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public VehicleModel Model { get; set; }
    public int Year { get; set; }
    public int OverhaulYear { get; set; }
    public string Number { get; set; }
    public int Kilometerage { get; set; }
    public string ImagePath { get; set; }
    public IList<CargoCategory> CargoCategories { get; set; }
}