using LongDistanceService.Domain.CQRS.Commands.Cargoes;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Services.Entities.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services.Entities;

public class CargoService(IMediator mediator) : ICargoService
{
    public async Task<IList<ICargoCategory>> GetCargoCategoriesAsync()
    {
        return [..await mediator.Send(new GetCargoCategoriesRequest())];
    }

    public async Task<bool> AddOrUpdateCargoCategoryAsync(IEditCargoCategory category)
    {
        return await mediator.Send(new EditCargoCategoryRequest()
        {
            Id = category.Id,
            Name = category.Name,
            UnitId = category.UnitId
        });
    }

    public async Task<bool> DeleteCargoCategoryAsync(int id)
    {
        return await mediator.Send(new DeleteCargoCategoryRequest(id));
    }

    public async Task<IList<IUnit>> GetUnitsAsync()
    {
        return [..await mediator.Send(new GetUnitsRequest())];
    }

    public async Task<bool> AddOrUpdateUnitAsync(IUnit unit)
    {
        return await mediator.Send(new EditUnitRequest { Id = unit.Id, Name = unit.Name });
    }

    public async Task<bool> DeleteUnitAsync(int id)
    {
        return await mediator.Send(new DeleteUnitRequest { Id = id });
    }

    public async Task<IList<ICargo>> GetCargoesAsync()
    {
        return [..await mediator.Send(new GetCargoesRequest())];
    }

    public async Task<bool> AddOrUpdateCargoAsync(IEditCargo category)
    {
        return await mediator.Send(new EditCargoRequest()
        {
            Id = category.Id,
            Name = category.Name,
            CategoryId = category.CategoryId
        });
    }

    public async Task<bool> DeleteCargoAsync(int id)
    {
        return await mediator.Send(new DeleteCargoRequest(id));
    }
}