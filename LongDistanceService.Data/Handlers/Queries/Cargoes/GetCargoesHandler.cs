using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Cargoes;

public class GetCargoesHandler(IApplicationDbContext context)
    : IRequestHandler<GetCargoCategoriesRequest, IList<CargoCategoryResponse>>
{
    public async Task<IList<CargoCategoryResponse>> Handle(GetCargoCategoriesRequest request,
        CancellationToken cancellationToken)
    {
        return await context.CargoCategories.Include(c => c.Unit).Select(c => new CargoCategoryResponse()
                { Id = c.Id, Name = c.Name, Unit = new UnitResponse() { Id = c.UnitId, Name = c.Unit.Name } })
            .ToListAsync(cancellationToken);
    }
}