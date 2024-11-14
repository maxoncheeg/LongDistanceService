using LongDistanceService.Data.Contexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.Identity;

public static class IdentityServicesExtensions
{
    public static IServiceCollection AddApplicationIdentity(this IServiceCollection @this)
    {
        @this.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddSignInManager();

        return @this;
    }
}