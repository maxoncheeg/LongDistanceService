namespace LongDistanceService.Domain.Models.Abstract.Vehicles;

public interface IVehicleInfo
{
    public int Id { get;}
    public string BrandAndModel { get;}
    public string LicensePlate { get;}
    public string? ImagePath { get; }
}