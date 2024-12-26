using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.CQRS.Responses.Vehicles;

public record VehicleInfoResponse(int Id, string BrandAndModel, string LicensePlate, string? ImagePath) : IVehicleInfo
{
}