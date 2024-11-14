using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IAccessTokenService
{
    public ITokenData GenerateToken(IUser user);
    public Task<IUser?> ValidateTokenAsync(string token);
}