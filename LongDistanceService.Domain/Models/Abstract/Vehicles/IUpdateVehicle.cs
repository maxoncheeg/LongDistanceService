namespace LongDistanceService.Domain.Models.Abstract.Vehicles;

public interface IEditVehicle
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public int Year { get; set; }
    public int OverhaulYear { get; set; }
    public string LicensePlate { get; set; }
    public decimal Kilometerage { get; set; }
    public string? ImagePath { get; set; }
    public int[] CargoCategoryIds { get; set; }
}