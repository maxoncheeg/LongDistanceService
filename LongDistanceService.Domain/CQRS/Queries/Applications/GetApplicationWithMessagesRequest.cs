using LongDistanceService.Domain.CQRS.Responses.Applications;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Applications;

public record GetApplicationWithMessagesRequest(int ApplicationId) : IRequest<ApplicationResponse?>;