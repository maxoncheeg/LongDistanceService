using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Vehicles;

public class VehicleModel : AbstractNameEntity
{
    public int BrandId { get; set; }
    public VehicleBrand Brand { get; set; }
}