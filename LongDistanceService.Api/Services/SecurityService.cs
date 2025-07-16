using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;
using LongDistanceService.Domain.Services.Entities.Abstract;
using LongDistanceService.Domain.Services.Identity.Abstract;

namespace LongDistanceService.Api.Services;

public class SecurityService(IAccessTokenService tokenService, ITokenManager tokenManager, IUserService userService)
    : ISecurityService
{
    public async Task<IUser?> GetCurrentUserAsync()
    {
        var token = tokenManager.Token;

        if (string.IsNullOrEmpty(token)) return null;

        var userData = await tokenService.GetUserDataFromTokenAsync(token);

        if (userData == null) return null;

        return await userService.GetUserAsync(userData.Id);
    }
}