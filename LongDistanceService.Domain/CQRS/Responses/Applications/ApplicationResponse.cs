using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Applications;

namespace LongDistanceService.Domain.CQRS.Responses.Applications;

public record ApplicationResponse(
    int Id,
    DateOnly Created,
    ApplicationState Status,
    int CreatorId,
    IList<IApplicationMessage> Messages) : IApplication;