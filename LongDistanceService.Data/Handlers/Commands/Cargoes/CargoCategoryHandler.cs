using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Cargoes;
using LongDistanceService.Domain.CQRS.Commands.Cargoes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Cargoes;

public class CargoCategoryHandler(IApplicationDbContext context) : IRequestHandler<EditCargoCategoryRequest, bool>, IRequestHandler<DeleteCargoCategoryRequest, bool>
{
    public async Task<bool> Handle(EditCargoCategoryRequest request, CancellationToken cancellationToken)
    {
        if (request.UnitId == 0) return false;
        
        var category = request.Id != 0
            ? await context.CargoCategories.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new CargoCategory();
        var unit = await context.Units.SingleOrDefaultAsync(b => b.Id == request.UnitId, cancellationToken: cancellationToken);
        
        if (unit == null || category == null) return false;
        try
        {
            category.Name = request.Name;
            category.Unit = unit;
            context.Update(category);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteCargoCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await context.CargoCategories.SingleOrDefaultAsync(b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        if (category == null) return false;
        try
        {
            context.Delete(category);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }
}