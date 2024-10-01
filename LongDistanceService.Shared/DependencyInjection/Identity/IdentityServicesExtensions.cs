using LongDistanceService.Data.Contexts;
using LongDistanceService.Shared.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.Identity;

public static class IdentityServicesExtensions
{
    public static IServiceCollection AddApplicationIdentity(this IServiceCollection @this)
    {
        @this.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddSignInManager();
        @this.AddScoped<IAuthenticationService, AuthenticationService>();

        return @this;
    }
}