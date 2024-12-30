using LongDistanceService.Domain.CQRS.Commands.Orders;
using LongDistanceService.Domain.CQRS.Queries.Orders;
using LongDistanceService.Domain.Models.Abstract.Order;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class OrderService(IMediator mediator) : IOrderService
{
    public async Task<IList<IOrderInfo>> GetOrdersInfo()
    {
        return [..await mediator.Send(new GetOrderInfosRequest())];
    }

    public async Task<IOrder?> GetOrderById(int orderId)
    {
        return await mediator.Send(new GetOrderRequest(orderId));
    }

    public async Task<bool> AddOrder(IOrderOnAdd o)
    {
        return await mediator.Send(new AddOrderRequest()
        {
            Cargoes = o.Cargoes,
            VehicleId = o.VehicleId,
            Drivers = o.Drivers,
            ReceiveCityId = o.ReceiveCityId,
            SendCityId = o.SendCityId,
            SendStreetId = o.SendStreetId,
            ReceiveStreetId = o.ReceiveStreetId,
            RouteLength = o.RouteLength,
            LoadingDate = o.LoadingDate,
            ReceiverType = o.ReceiverType,
            SenderType = o.SenderType,
            ReceiverId = o.ReceiverId,
            SenderId = o.SenderId,
            SendHouseNumber = o.SendHouseNumber,
            ReceiveHouseNumber = o.ReceiveHouseNumber,
            State = o.State
        });
    }
}