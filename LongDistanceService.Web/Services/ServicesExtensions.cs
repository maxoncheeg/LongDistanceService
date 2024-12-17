using LongDistanceService.Domain.Services;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Web.Services.Abstract;

namespace LongDistanceService.Web.Services;

public static class ServicesExtensions
{
    public static IServiceCollection AddAuthorizationServices(this IServiceCollection @this)
    {
        return @this
            .AddScoped<ISecurityService, SecurityService>()
            .AddScoped<IIdentityService, IdentityService>();
    }

    public static IServiceCollection AddDomainAuthorizationServices(this IServiceCollection @this)
    {
        return @this
            .AddScoped<IAccessTokenService, AccessTokenService>()
            .AddScoped<IScenarioService, ScenarioService>()
            .AddScoped<IPasswordHasher, BCryptPasswordHasher>();
    }

    public static IServiceCollection AddLdsServices(this IServiceCollection @this)
    {
        return @this
            .AddScoped<IApplicationService, ApplicationService>()
            .AddScoped<IExcelSqlConverter, ExcelSqlConverter>()
            .AddScoped<IWordSqlConverter, WordSqlConverter>()
            .AddScoped<IVehicleService, VehicleService>()
            .AddScoped<ICargoService, CargoService>();
    }
}