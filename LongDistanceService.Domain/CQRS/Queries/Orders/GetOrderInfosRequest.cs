using LongDistanceService.Domain.CQRS.Responses.Orders;

namespace LongDistanceService.Domain.CQRS.Queries.Orders;

public record GetOrderInfosRequest : ScrolledRequest<OrderInfoResponse>
{
    
}