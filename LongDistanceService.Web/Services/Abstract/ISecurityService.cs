using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Web.Services.Abstract;

public interface ISecurityService
{
    public Task<IUser?> ValidateTokenAsync(string token);
    public Task<string?> RefreshTokenAsync(string refreshToken, string expiredToken);
    public Task<bool> IsAdminAsync(IUser user);
    public Task<IUserRights?> GetUserRightsToPageAsync(IUser user, string route);
}