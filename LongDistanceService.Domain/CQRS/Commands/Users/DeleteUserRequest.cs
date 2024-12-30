using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public record DeleteUserRequest(int Id) : IRequest<bool>;