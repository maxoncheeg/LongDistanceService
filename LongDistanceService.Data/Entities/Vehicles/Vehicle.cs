using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Vehicles;

public class Vehicle : IEntity
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public VehicleModel Model { get; set; } = new();
    public int Year { get; set; }
    public int OverhaulYear { get; set; }
    public string LicensePlate { get; set; } = String.Empty;
    public int LoadCapacity { get; set; }
    public decimal Kilometerage { get; set; }
    public string? ImagePath { get; set; }
    public IList<VehicleCargoCategory> VehicleCargoCategories { get; set; } = new List<VehicleCargoCategory>();
    public IList<Order> Orders { get; set; } = new List<Order>();
}