using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities;
using LongDistanceService.Data.Entities.Vehicles;
using LongDistanceService.Domain.CQRS.Commands.Vehicles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Vehicles;

public class VehicleHandler(IApplicationDbContext context) : IRequestHandler<DeleteVehicleRequest>, IRequestHandler<EditVehicleRequest>
{
    public async Task Handle(DeleteVehicleRequest request, CancellationToken cancellationToken)
    {
        var vehicle = await context.Vehicles.Where(v => v.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

        if (vehicle != null)
        {
            context.Delete(vehicle);
            await context.SaveAsync();
        }
    }

    public async Task Handle(EditVehicleRequest request, CancellationToken cancellationToken)
    {
        var vehicle = await context.Vehicles.Where(v => v.Id == request.Id).Include(p => p.VehicleCargoCategories).FirstOrDefaultAsync(cancellationToken) ??
                      new Vehicle();
        
        var cargoCategories = await context.CargoCategories.Where(c => request.CargoCategoryIds.Contains(c.Id)).ToListAsync(cancellationToken);
        var model = await context.VehicleModels.Where(m => m.Id == request.ModelId).SingleOrDefaultAsync(cancellationToken);

        if (model == null) return;
        
        vehicle.ImagePath = request.ImagePath;
        vehicle.Kilometerage = request.Kilometerage;
        vehicle.LicensePlate = request.LicensePlate;
        vehicle.Year = request.Year;
        vehicle.OverhaulYear = request.OverhaulYear;
        vehicle.Model = model;
        vehicle.VehicleCargoCategories = [];

        foreach (var category in cargoCategories)
                vehicle.VehicleCargoCategories.Add(new VehicleCargoCategory() { Category = category, Vehicle = vehicle});
        
        if(request.Id == 0)
            await context.CreateAsync(vehicle);
        else
            context.Update(vehicle);
        
        await context.SaveAsync();
    }
}