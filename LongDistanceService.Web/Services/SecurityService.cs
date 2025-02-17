using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Web.Services.Abstract;
using MediatR;

namespace LongDistanceService.Web.Services;

public class SecurityService(IMediator mediator, IIdentityService identityService, IAccessTokenService accessTokenService) : ISecurityService
{
    public async Task<bool> IsAdminAsync()
    {
        var role = await GetUserRoleAsync();
        return role is UserRole.Admin;
    }

    public async Task<bool> IsManagementAsync()
    {
        var role = await GetUserRoleAsync();
        return role is UserRole.Admin or UserRole.Manager;
    }

    public async Task<bool> IsDriverAsync()
    {
        var role = await GetUserRoleAsync();
        return role is UserRole.Driver;
    }

    public async Task<bool> IsClientAsync()
    {
        var role = await GetUserRoleAsync();
        return role is UserRole.Client;
    }

    public async Task<UserRole?> GetUserRoleAsync()
    {
        var userId = await GetUserIdAsync();
        if (userId == null) return null;

        return await mediator.Send(new GetUserRoleRequest(userId.Value));
    }

    private async Task<int?> GetUserIdAsync()
    {
        var token = await identityService.ExtractTokenAsync();
        return token == null ? null : (await accessTokenService.GetUserDataFromTokenAsync(token))?.Id;
    }
}