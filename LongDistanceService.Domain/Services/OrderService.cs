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
}