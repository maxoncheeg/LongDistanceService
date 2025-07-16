using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Services.Identity.Abstract;

public interface IAccessTokenService
{
    public ITokenData GenerateToken(IUser user);
    public string GenerateRefreshToken(IUser user);
    public Task<string?> RefreshTokenAsync(string refreshToken, string expiredToken);
    public Task<ILoginUser?> GetUserDataFromTokenAsync(string token);
    public Task<bool> ValidateTokenAsync(string token);
}