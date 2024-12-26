using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.CQRS.Responses.Vehicles;

public class VehicleResponse : IVehicle
{
    public int Id { get; set; }
    public IModel Model { get; set; } = null!;
    public int Year { get; set; }
    public int OverhaulYear { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public decimal Kilometerage { get; set; }
    public int LoadCapacity { get; set; }
    public string? ImagePath { get; set; }
    public IList<ICargoCategory> CargoCategories { get; set; } = [];
}