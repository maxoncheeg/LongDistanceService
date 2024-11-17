using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IAccessTokenService
{
    public ITokenData GenerateToken(IUser user);
    public string GenerateRefreshToken(IUser user);
    public Task<string?> RefreshTokenAsync(string refreshToken, string expiredToken);
    public Task<IUser?> GetUserDataFromTokenAsync(string token);
    public Task<bool> ValidateTokenAsync(string token);
}