using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public record UpdateUserEmailVerificationRequest(int UserId, bool Verified) : IRequest<bool>;