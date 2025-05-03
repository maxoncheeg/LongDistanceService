using LongDistanceService.Domain.Models.Abstract.Auth;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IIdentityService
{
    public Task<IAuthResult> LoginAsync(string login, string password);
    public Task<IAuthResult> LoginByProviderAsync(string provider, string providerId);
    public Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
    public Task<bool> ChangeLoginAsync(string userId, string password, string newLogin);
    public Task<bool> AddLoginProviderAsync(string userId, string provider, string providerId);
}