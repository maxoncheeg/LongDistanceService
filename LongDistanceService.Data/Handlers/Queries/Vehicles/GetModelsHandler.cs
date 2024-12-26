using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Vehicles;

public class GetModelsHandler(IApplicationDbContext context) : IRequestHandler<GetModelsRequest, IList<ModelResponse>>
{
    public async Task<IList<ModelResponse>> Handle(GetModelsRequest request, CancellationToken cancellationToken)
    {
        return await context.VehicleModels.Include(m => m.Brand).Select(m => new ModelResponse()
        {
            Id = m.Id,
            Name = m.Name,
            Brand = new BrandResponse() { Id = m.Brand.Id, Name = m.Brand.Name }
        }).ToListAsync(cancellationToken);
    }
}