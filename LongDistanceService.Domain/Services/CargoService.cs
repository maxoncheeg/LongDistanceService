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
}