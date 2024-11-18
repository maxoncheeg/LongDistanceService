using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public class IsUserAdminRequest : IRequest<bool>
{
    public int UserId { get; set; }
}