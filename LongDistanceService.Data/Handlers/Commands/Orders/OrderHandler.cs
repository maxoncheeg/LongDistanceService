using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities;
using LongDistanceService.Domain.CQRS.Commands.Orders;
using LongDistanceService.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Orders;

public class OrderHandler(IApplicationDbContext context) : IRequestHandler<AddOrderRequest, bool>
{
    public async Task<bool> Handle(AddOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // todo: legals and individuals new scheme
            Order order = new()
            {
                RouteLength = request.RouteLength,
                LoadingDate = request.LoadingDate.ToUniversalTime(),
                
                SendHouseNumber = request.SendHouseNumber,
                ReceiveHouseNumber = request.ReceiveHouseNumber,
                State = request.State,
                Vehicle =
                    await context.Vehicles.SingleOrDefaultAsync(v => v.Id == request.VehicleId, cancellationToken) ??
                    throw new NullReferenceException(),
                SendCity =
                    await context.Cities.SingleOrDefaultAsync(v => v.Id == request.SendCityId, cancellationToken) ??
                    throw new NullReferenceException(),
                ReceiveCity =
                    await context.Cities.SingleOrDefaultAsync(v => v.Id == request.ReceiveCityId, cancellationToken) ??
                    throw new NullReferenceException(),
                SendStreet =
                    await context.Streets.SingleOrDefaultAsync(v => v.Id == request.SendStreetId, cancellationToken) ??
                    throw new NullReferenceException(),
                ReceiveStreet =
                    await context.Streets.SingleOrDefaultAsync(v => v.Id == request.ReceiveStreetId,
                        cancellationToken) ??
                    throw new NullReferenceException()
            };

            var drivers =
                await context.Drivers.Where(d => request.Drivers.Contains(d.Id)).ToListAsync(cancellationToken) ??
                throw new NullReferenceException();
            order.OrderDrivers = [];
            foreach (var d in drivers)
                order.OrderDrivers.Add(new OrderDriver() { Order = order, Driver = d });

            var cargoes =
                await context.Cargoes.ToListAsync(cancellationToken) ??
                throw new NullReferenceException();

            order.OrderCargoes = [];
            foreach (var orderCargo in request.Cargoes)
            {
                OrderCargo o = new()
                {
                    Price = orderCargo.Price,
                    Cargo = cargoes.First(x => x.Id == orderCargo.CargoId),
                    Order = order,
                    Weight = orderCargo.Weight,
                    Amount = orderCargo.Amount,
                };
                order.OrderCargoes.Add(o);
            }

                
            

            await context.CreateAsync(order);
            await context.SaveAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}