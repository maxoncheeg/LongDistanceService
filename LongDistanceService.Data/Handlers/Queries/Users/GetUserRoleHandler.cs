using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class GetUserRoleHandler(IApplicationDbContext context) : IRequestHandler<GetUserRoleRequest, Roles?>
{
    public async Task<Roles?> Handle(GetUserRoleRequest request, CancellationToken cancellationToken)
    {
        return Roles.Client;
        // return (await context.Users
        //         .Include(u => u.Role)
        //         .SingleOrDefaultAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken)
        //     )?.Role.Type;
    }
}