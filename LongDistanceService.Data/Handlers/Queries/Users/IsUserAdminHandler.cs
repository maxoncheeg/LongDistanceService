using LongDistanceService.Data.Contexts;
using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class IsUserAdminHandler(IApplicationDbContext context) : IRequestHandler<IsUserAdminRequest, bool>
{
    public async Task<bool> Handle(IsUserAdminRequest request, CancellationToken cancellationToken)
    {
        var result = await context.MenuTabRights.FirstOrDefaultAsync(r => r.UserId == request.UserId,
            cancellationToken: cancellationToken);

        return result != null;
    }
}