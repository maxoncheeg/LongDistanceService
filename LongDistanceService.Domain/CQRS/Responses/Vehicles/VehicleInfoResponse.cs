using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.CQRS.Responses.Vehicles;

public record VehicleInfoResponse(int Id, string Name, string LicensePlate, string? ImagePath) : IVehicleInfo
{
}