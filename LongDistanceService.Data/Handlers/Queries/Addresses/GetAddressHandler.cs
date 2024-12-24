using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Addresses;
using LongDistanceService.Domain.CQRS.Responses.Addresses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Addresses;

public class GetAddressHandler(IApplicationDbContext context) : IRequestHandler<GetCitiesRequest, IList<CityResponse>>,
    IRequestHandler<GetStreetsRequest, IList<StreetResponse>>
{
    public async Task<IList<CityResponse>> Handle(GetCitiesRequest request, CancellationToken cancellationToken)
    {
        return await context.Cities.Select(c => new CityResponse() { Id = c.Id, Name = c.Name }).Take(request.Take)
            .Skip(request.Skip).ToListAsync(cancellationToken);
    }

    public async Task<IList<StreetResponse>> Handle(GetStreetsRequest request, CancellationToken cancellationToken)
    {
        return await context.Streets.Select(s => new StreetResponse() { Id = s.Id, Name = s.Name }).Take(request.Take)
            .Skip(request.Skip).ToListAsync(cancellationToken);
    }
}