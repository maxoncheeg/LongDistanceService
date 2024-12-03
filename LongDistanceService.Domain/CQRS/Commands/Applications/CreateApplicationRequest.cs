using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Applications;

public record CreateApplicationRequest(int UserId, string Text) : IRequest;