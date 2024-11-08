using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Vehicles;

public class VehicleBrand : AbstractNameEntity
{
    public IList<VehicleModel> Models { get; set; } = new List<VehicleModel>();
}