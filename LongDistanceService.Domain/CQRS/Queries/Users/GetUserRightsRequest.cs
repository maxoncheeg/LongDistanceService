using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.Models.Abstract;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public record GetUserRightsRequest(IUser User, string Route) : IRequest<UserRightsResponse?>;