using LongDistanceService.Domain.CQRS.Commands.Addresses;
using LongDistanceService.Domain.CQRS.Queries.Addresses;
using LongDistanceService.Domain.Models.Abstract.Addresses;
using LongDistanceService.Domain.Services.Entities.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services.Entities;

public class AddressService(IMediator mediator) : IAddressService
{
    public async Task<IList<ICity>> GetCitiesAsync()
    {
        return [..await mediator.Send(new GetCitiesRequest())];
    }

    public async Task<bool> AddOrUpdateCityAsync(ICity city)
    {
        return await mediator.Send(new EditCityRequest() { Id = city.Id, Name = city.Name });
    }

    public async Task<bool> DeleteCityAsync(int id)
    {
        return await mediator.Send(new DeleteCityRequest() { Id = id });
    }

    public async Task<IList<IStreet>> GetStreetsAsync()
    {
        return [..await mediator.Send(new GetStreetsRequest())];
    }

    public async Task<bool> AddOrUpdateStreetAsync(IStreet street)
    {
        return await mediator.Send(new EditStreetRequest() { Id = street.Id, Name = street.Name });
    }

    public async Task<bool> DeleteStreetAsync(int id)
    {
        return await mediator.Send(new DeleteStreetRequest() { Id = id });
    }
}