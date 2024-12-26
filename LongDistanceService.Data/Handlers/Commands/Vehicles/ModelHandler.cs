using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Vehicles;
using LongDistanceService.Domain.CQRS.Commands.Vehicles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Vehicles;

public class ModelHandler(IApplicationDbContext context)
    : IRequestHandler<EditModelRequest, bool>, IRequestHandler<DeleteModelRequest, bool>
{
    public async Task<bool> Handle(EditModelRequest request, CancellationToken cancellationToken)
    {
        if (request.BrandId == 0) return false;
        
        var model = request.Id != 0
            ? await context.VehicleModels.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new VehicleModel();
        var brand = await context.VehicleBrands.SingleOrDefaultAsync(b => b.Id == request.BrandId, cancellationToken: cancellationToken);
        
        if (brand == null || model == null) return false;
        try
        {
            model.Name = request.Name;
            model.Brand = brand;
            context.Update(model);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteModelRequest request, CancellationToken cancellationToken)
    {
        var model = await context.VehicleModels.SingleOrDefaultAsync(b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        if (model == null) return false;
        
        try
        {
            context.Delete(model);
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