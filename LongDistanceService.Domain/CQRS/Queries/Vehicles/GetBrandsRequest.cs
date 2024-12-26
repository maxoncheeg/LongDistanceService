using LongDistanceService.Domain.CQRS.Responses.Vehicles;

namespace LongDistanceService.Domain.CQRS.Queries.Vehicles;

public record GetBrandsRequest : ScrolledRequest<BrandResponse>
{
    
}