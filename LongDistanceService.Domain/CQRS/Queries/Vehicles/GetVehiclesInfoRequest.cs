using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using LongDistanceService.Domain.Models.Options;

namespace LongDistanceService.Domain.CQRS.Queries.Vehicles;

public record GetVehiclesInfoRequest(VehicleSearchOptions? Options = null) : ScrolledRequest<VehicleInfoResponse>;