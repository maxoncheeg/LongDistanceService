using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Applications;

namespace LongDistanceService.Domain.CQRS.Responses.Applications;

public record ApplicationInfoResponse(int Id, DateOnly Created, DateTime? LastMessageDate, ApplicationState Status) : IApplicationInfo;