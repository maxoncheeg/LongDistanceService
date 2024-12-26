using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Cargoes;

public class GetCargoesHandler(IApplicationDbContext context)
    : IRequestHandler<GetCargoCategoriesRequest, IList<CargoCategoryResponse>>, IRequestHandler<GetCargoesRequest, IList<CargoResponse>>
{
    public async Task<IList<CargoCategoryResponse>> Handle(GetCargoCategoriesRequest request,
        CancellationToken cancellationToken)
    {
        return await context.CargoCategories.Include(c => c.Unit).Select(c => new CargoCategoryResponse()
                { Id = c.Id, Name = c.Name, Unit = new UnitResponse() { Id = c.UnitId, Name = c.Unit.Name } })
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<CargoResponse>> Handle(GetCargoesRequest request, CancellationToken cancellationToken)
    {
        return await context.Cargoes.Include(c => c.Category).ThenInclude(c => c.Unit)
            .Select(c => new CargoResponse()
            {
                Id = c.Id,
                Name = c.Name,
                Category = new CargoCategoryResponse()
                {
                    Id = c.Category.Id,
                    Name = c.Category.Name,
                    Unit = new UnitResponse()
                    {
                        Id = c.Category.Unit.Id,
                        Name = c.Category.Unit.Name
                    }
                }
            }).Take(request.Take).Skip(request.Skip).ToListAsync(cancellationToken);
    }
}