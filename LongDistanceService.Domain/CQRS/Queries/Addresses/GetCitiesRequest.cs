using LongDistanceService.Domain.CQRS.Responses.Addresses;

namespace LongDistanceService.Domain.CQRS.Queries.Addresses;

public record GetCitiesRequest : ScrolledRequest<CityResponse>
{
    
}