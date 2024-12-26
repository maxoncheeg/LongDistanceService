using LongDistanceService.Domain.CQRS.Commands.Vehicles;
using LongDistanceService.Domain.CQRS.Queries.Vehicles;
using LongDistanceService.Domain.Models.Abstract.Vehicles;
using LongDistanceService.Domain.Models.Options;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class VehicleService(IMediator mediator) : IVehicleService
{
    public async Task<IList<IVehicleInfo>> GetVehiclesAsync(int take = 30, int skip = 0,
        VehicleSearchOptions? options = null)
    {
        return [..await mediator.Send(new GetVehiclesInfoRequest() { Skip = skip, Take = take })];
    }

    public async Task<IList<IModel>> GetModelsAsync()
    {
        return [..await mediator.Send(new GetModelsRequest())];
    }

    public async Task<IVehicle?> GetVehicleAsync(int id)
    {
        return await mediator.Send(new GetVehicleRequest(id));
    }

    public async Task AddOrUpdateVehicleAsync(IEditVehicle vehicle)
    {
        await mediator.Send(new EditVehicleRequest()
        {
            Id = vehicle.Id,
            CargoCategoryIds = vehicle.CargoCategoryIds,
            ModelId = vehicle.ModelId,
            ImagePath = vehicle.ImagePath,
            Kilometerage = vehicle.Kilometerage,
            LicensePlate = vehicle.LicensePlate,
            OverhaulYear = vehicle.OverhaulYear,
            Year = vehicle.Year
        });
    }

    public async Task DeleteVehicleAsync(int id)
    {
        await mediator.Send(new DeleteVehicleRequest(id));
    }

    public async Task<IList<IBrand>> GetBrandsAsync()
    {
        return [..await mediator.Send(new GetBrandsRequest())];
    }

    public async Task<bool> AddOrUpdateBrandAsync(IBrand brand)
    {
        return await mediator.Send(new EditBrandRequest() { Id = brand.Id, Name = brand.Name });
    }

    public async Task<bool> DeleteBrandAsync(int id)
    {
        return await mediator.Send(new DeleteBrandRequest(id));
    }

    public async Task<bool> AddOrUpdateModelAsync(IEditModel model)
    {
        return await mediator.Send(new EditModelRequest() { Id = model.Id, Name = model.Name, BrandId = model.BrandId});
    }

    public async Task<bool> DeleteModelAsync(int id)
    {
        return await mediator.Send(new DeleteModelRequest(id));
    }
}