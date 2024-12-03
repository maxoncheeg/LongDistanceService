using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Applications;

public record FinishApplicationRequest(int ApplicationId) : IRequest;