using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.CQRS.Responses.Applications;

public record ApplicationInfoResponse(int Id, DateOnly Created, DateTime? LastMessageDate, ApplicationState Status) : IApplicationInfo;