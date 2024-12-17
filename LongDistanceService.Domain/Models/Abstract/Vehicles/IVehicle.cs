using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.Models.Abstract.Vehicles;

public interface IVehicle
{
    public int Id { get; set; }
    public IModel Model { get; set; }
    public int Year { get; set; }
    public int OverhaulYear { get; set; }
    public string LicensePlate { get; set; }
    public decimal Kilometerage { get; set; }
    public string? ImagePath { get; set; }
    public IList<ICargoCategory> CargoCategories { get; set; }
}