using LongDistanceService.Domain.CQRS.Responses.Orders;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Orders;

public record GetOrderRequest(int OrderId) : IRequest<OrderResponse?>;