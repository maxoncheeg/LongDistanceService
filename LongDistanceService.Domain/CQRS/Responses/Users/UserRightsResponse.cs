using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.CQRS.Responses.Users;

public record UserRightsResponse(bool Read = false, bool Write = false, bool Edit = false, bool Delete = false)
    : IUserRights;