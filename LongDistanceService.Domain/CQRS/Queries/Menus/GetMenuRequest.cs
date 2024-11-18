using LongDistanceService.Domain.CQRS.Responses.Menus;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Menus;

public class GetMenuRequest : IRequest<IList<MenuItemResponse>>
{
    public int UserId { get; set; }
}