using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Vehicles;

public class VehicleModel : AbstractNameEntity
{
    public int BrandId { get; set; }
    public VehicleBrand Brand { get; set; } = new();
    public IList<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}