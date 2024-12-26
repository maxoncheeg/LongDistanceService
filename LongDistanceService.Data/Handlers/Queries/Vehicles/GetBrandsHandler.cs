using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Vehicles;

public class GetBrandsHandler(IApplicationDbContext context) : IRequestHandler<GetBrandsRequest, IList<BrandResponse>>
{
    public async Task<IList<BrandResponse>> Handle(GetBrandsRequest request, CancellationToken cancellationToken)
    {
        return await context.VehicleBrands.Select(v => new BrandResponse() { Id = v.Id, Name = v.Name })
            .ToListAsync(cancellationToken);
    }
}