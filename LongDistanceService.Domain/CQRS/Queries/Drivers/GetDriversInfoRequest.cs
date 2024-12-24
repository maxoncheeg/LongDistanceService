using LongDistanceService.Domain.CQRS.Responses.Drivers;

namespace LongDistanceService.Domain.CQRS.Queries.Drivers;

public record GetDriversInfoRequest : ScrolledRequest<DriverInfoResponse>
{
    
}