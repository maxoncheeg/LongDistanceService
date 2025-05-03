using LongDistanceService.Domain.Services;
using LongDistanceService.Domain.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.Services;

public static class LongDistanceServiceExtensions
{
    public static IServiceCollection AddLongDistanceServices(this IServiceCollection @this) =>
        @this
            .AddScoped<IIdentityService, IdentityService>()
            .AddTransient<IAccessTokenService, AccessTokenService>()
            .AddScoped<IPasswordHasher, BCryptPasswordHasher>()
            .AddScoped<IVehicleService, VehicleService>();
}