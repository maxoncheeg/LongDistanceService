using Microsoft.AspNetCore.Identity;

namespace LongDistanceService.Shared.Services.Identity;

public class AuthenticationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) : IAuthenticationService
{
    public async Task<bool> RegisterUser(IIdentityUser user)
    {
        var identityUser = new IdentityUser()
        {
            Email = user.Email,
            UserName = user.Email
        };
        
        userManager.PasswordValidators.Clear();
        var result = await userManager.CreateAsync(identityUser, user.Password);
        
        return result.Succeeded;
    }

    public async Task<bool> AuthenticateUser(IIdentityUser user)
    {
        var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, false, true);
            
        return result.Succeeded;
    }

    public async Task<bool> LogOut(IIdentityUser user)
    {
        await signInManager.SignOutAsync();
        return true;
    }
}