using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Users;

public record GetRolesRequest : IRequest<IList<RoleResponse>>;