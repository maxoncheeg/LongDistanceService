using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public record GetUserByIdRequest(int Id) : IRequest<UserResponse?>;