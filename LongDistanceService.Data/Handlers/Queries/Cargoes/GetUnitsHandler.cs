using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Cargoes;

public class GetUnitsHandler(IApplicationDbContext context) : IRequestHandler<GetUnitsRequest, IList<UnitResponse>>
{
    public async Task<IList<UnitResponse>> Handle(GetUnitsRequest request, CancellationToken cancellationToken)
    {
        return await context.Units.Select(u => new UnitResponse() { Id = u.Id, Name = u.Name }).ToListAsync(cancellationToken);
    }
}