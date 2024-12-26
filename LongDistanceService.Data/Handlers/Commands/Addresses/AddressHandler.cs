using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Addresses;
using LongDistanceService.Domain.CQRS.Commands.Addresses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Addresses;

public class AddressHandler(IApplicationDbContext context) : IRequestHandler<EditCityRequest, bool>,
    IRequestHandler<DeleteCityRequest, bool>,
    IRequestHandler<EditStreetRequest, bool>, IRequestHandler<DeleteStreetRequest, bool>
{
    public async Task<bool> Handle(EditCityRequest request, CancellationToken cancellationToken)
    {
        var city = request.Id != 0
            ? await context.Cities.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new City();

        if (city == null) return false;

        try
        {
            city.Name = request.Name;
            context.Update(city);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteCityRequest request, CancellationToken cancellationToken)
    {
        var city = await context.Cities.SingleOrDefaultAsync(b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        if (city == null) return false;

        try
        {
            context.Delete(city);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(EditStreetRequest request, CancellationToken cancellationToken)
    {
        var street = request.Id != 0
            ? await context.Streets.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new Street();

        if (street == null) return false;
        try
        {
            street.Name = request.Name;
            context.Update(street);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteStreetRequest request, CancellationToken cancellationToken)
    {
        var street =
            await context.Streets.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken);

        if (street == null) return false;
        
        try
        {
            context.Delete(street);
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