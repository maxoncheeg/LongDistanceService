using LongDistanceService.Data.Entities.Vehicles;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;

namespace LongDistanceService.Data.Mappings;

public static class VehicleMappingExtensions
{
    public static IQueryable<VehicleInfoResponse> ToVehicleInfoResponse(this IQueryable<Vehicle> @this)
    {
        return @this.Select(vehicle => new VehicleInfoResponse(
            vehicle.Id,
            vehicle.Model.Brand + " " + vehicle.Model.Name, 
            vehicle.LicensePlate, 
            vehicle.ImagePath));
    }
}