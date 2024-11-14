using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Vehicles;

public class VehicleBrand : AbstractNameEntity
{
    public IList<VehicleModel> Models { get; set; } = new List<VehicleModel>();
}