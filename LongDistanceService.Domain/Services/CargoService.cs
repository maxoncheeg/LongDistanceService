using LongDistanceService.Domain.CQRS.Commands.Cargoes;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class CargoService(IMediator mediator) : ICargoService
{
    public async Task<IList<ICargoCategory>> GetCargoCategoriesAsync()
    {
        return [..await mediator.Send(new GetCargoCategoriesRequest())];
    }

    public Task<bool> AddOrUpdateCargoCategoryAsync(ICargoCategory category)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCargoCategoryAsync(int id)
    {
        throw new NotImplementedException();
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

    public Task<IList<ICargo>> GetCargoesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddOrUpdateCargoAsync(IUnit category)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteCargoAsync(int id)
    {
        throw new NotImplementedException();
    }
}