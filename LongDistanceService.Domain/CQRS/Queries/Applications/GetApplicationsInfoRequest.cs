using LongDistanceService.Domain.CQRS.Responses.Applications;

namespace LongDistanceService.Domain.CQRS.Queries.Applications;

public record GetApplicationsInfoRequest(int UserId) : ScrolledRequest<ApplicationInfoResponse>;