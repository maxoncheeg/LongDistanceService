using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Cargoes;
using LongDistanceService.Domain.CQRS.Commands.Cargoes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Cargoes;

public class CargoHandler(IApplicationDbContext context) : IRequestHandler<EditCargoRequest, bool>, IRequestHandler<DeleteCargoRequest, bool>
{
    public async Task<bool> Handle(EditCargoRequest request, CancellationToken cancellationToken)
    {
        if (request.CategoryId == 0) return false;
        
        var cargo = request.Id != 0
            ? await context.Cargoes.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new Cargo();
        var category = await context.CargoCategories.SingleOrDefaultAsync(b => b.Id == request.CategoryId, cancellationToken: cancellationToken);
        
        if (category == null || cargo == null) return false;
        try
        {
            cargo.Name = request.Name;
            cargo.Category = category;
            context.Update(cargo);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public  async Task<bool> Handle(DeleteCargoRequest request, CancellationToken cancellationToken)
    {
        var cargo = await context.Cargoes.SingleOrDefaultAsync(b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        if (cargo == null) return false;
        try
        {
            context.Delete(cargo);
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