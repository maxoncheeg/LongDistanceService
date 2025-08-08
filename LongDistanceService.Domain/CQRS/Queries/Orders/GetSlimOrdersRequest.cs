using LongDistanceService.Domain.CQRS.Responses.Orders;

namespace LongDistanceService.Domain.CQRS.Queries.Orders;

public record GetSlimOrdersRequest(int UserId) : ScrolledRequest<SlimOrderResponse>;