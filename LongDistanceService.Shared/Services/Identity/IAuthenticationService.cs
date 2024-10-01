namespace LongDistanceService.Shared.Services.Identity;

public interface IAuthenticationService
{
    public Task<bool> RegisterUser(IIdentityUser user);
    public Task<bool> AuthenticateUser(IIdentityUser user);
    public Task<bool> LogOut(IIdentityUser user);
} 