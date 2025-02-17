using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class GetRolesHandler(IApplicationDbContext context) : IRequestHandler<GetRolesRequest, IList<RoleResponse>>
{
    public async Task<IList<RoleResponse>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
    {
        return await context.Roles.Select(r => new RoleResponse() { Id = r.Id, Type = r.Type }).ToListAsync(cancellationToken);
    }
}