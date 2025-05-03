using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public record GetLoginUserByLoginRequest(string Login) : IRequest<LoginUserResponse?>
{
}