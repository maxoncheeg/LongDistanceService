using LongDistanceService.Domain.Models.Abstract.Auth;

namespace LongDistanceService.Domain.Services.Identity.Abstract;

public interface IIdentityService
{
    public Task<IAuthResult> LoginAsync(string login, string password);
    public Task<IAuthResult> LoginAsync(string token);
    public Task<IAuthResult> LoginByProviderAsync(string provider, string providerId);
    public Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    public Task<bool> ChangeLoginAsync(int userId, string password, string newLogin);
    public Task<bool> AddLoginProviderAsync(int userId, string provider, string providerId);
}