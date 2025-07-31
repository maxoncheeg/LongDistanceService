using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Profile;

public record GetUserProfileRequest(int UserId) : IRequest<UserProfileResponse?>;