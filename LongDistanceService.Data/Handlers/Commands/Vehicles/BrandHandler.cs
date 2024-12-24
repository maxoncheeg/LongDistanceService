using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Vehicles;
using LongDistanceService.Domain.CQRS.Commands.Vehicles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Vehicles;

public class BrandHandler(IApplicationDbContext context) : IRequestHandler<EditBrandRequest, bool>, IRequestHandler<DeleteBrandRequest, bool>
{
    public async Task<bool> Handle(EditBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = request.Id != 0 ? await context.VehicleBrands.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new VehicleBrand();

        if (brand == null) return false;
        
        brand.Name = request.Name;
        context.Update(brand);
        await context.SaveAsync();
        return true;
    }

    public async Task<bool> Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = await context.VehicleBrands.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

        if (brand == null) return false;
        
        context.Delete(brand);
        await context.SaveAsync();
        return true;
    }
}