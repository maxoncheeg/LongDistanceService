using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public class GetUserByLoginRequest : IRequest<UserResponse?>
{
    public string Login { get; set; } = String.Empty;
}