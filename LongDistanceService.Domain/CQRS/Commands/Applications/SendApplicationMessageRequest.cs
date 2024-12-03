using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Applications;

public record SendApplicationMessageRequest(int UserId, int ApplicationId, string Text, int? AnsweredAt = null) : IRequest;