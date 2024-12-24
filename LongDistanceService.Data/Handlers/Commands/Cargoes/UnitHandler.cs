using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Commands.Cargoes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Unit = LongDistanceService.Data.Entities.Cargoes.Unit;

namespace LongDistanceService.Data.Handlers.Commands.Cargoes;

public class UnitHandler(IApplicationDbContext context): IRequestHandler<EditUnitRequest, bool>, IRequestHandler<DeleteUnitRequest, bool>
{
    public async Task<bool> Handle(EditUnitRequest request, CancellationToken cancellationToken)
    {
        var unit = request.Id != 0 ? await context.Units.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new Unit();

        if (unit == null) return false;
        
        unit.Name = request.Name;
        context.Update(unit);
        await context.SaveAsync();
        return true;
    }

    public async Task<bool> Handle(DeleteUnitRequest request, CancellationToken cancellationToken)
    {
        var unit = await context.Units.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

        if (unit == null) return false;
        
        context.Delete(unit);
        await context.SaveAsync();
        return true;
    }
}