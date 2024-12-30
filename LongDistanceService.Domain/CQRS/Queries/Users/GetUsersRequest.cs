using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public class GetUsersRequest : IRequest<IList<UserResponse>>
{
    
}