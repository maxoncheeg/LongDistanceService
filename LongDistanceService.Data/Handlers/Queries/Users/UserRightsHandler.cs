using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Models.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class UserRightsHandler(IApplicationDbContext context) : IRequestHandler<IsUserAdminRequest, bool>,
    IRequestHandler<GetUserRightsRequest, UserRightsResponse?>
{
    public async Task<bool> Handle(IsUserAdminRequest request, CancellationToken cancellationToken)
    {
        var result = await context.Users.Include(p => p.Role).SingleOrDefaultAsync(r => r.Id == request.UserId,
            cancellationToken: cancellationToken);

        return result?.Role.Name == "admin";
    }

    public async Task<UserRightsResponse?> Handle(GetUserRightsRequest request, CancellationToken cancellationToken)
    {
        var result = await (from user in context.Users
            join role in context.Roles on user.RoleId equals role.Id 
            join right in context.MenuTabRights on role.Id equals right.RoleId
            join tab in context.MenuTabs on right.MenuTabId equals tab.Id
            where tab.FunctionName == request.Route && user.Id == request.User.Id
            select right).FirstAsync(cancellationToken: cancellationToken);

        return new UserRightsResponse(result.R, result.W, result.E, result.D);
    }
}