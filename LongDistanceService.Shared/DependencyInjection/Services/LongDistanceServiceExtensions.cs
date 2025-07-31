using LongDistanceService.Domain.Services.Entities;
using LongDistanceService.Domain.Services.Entities.Abstract;
using LongDistanceService.Domain.Services.Factories;
using LongDistanceService.Domain.Services.Factories.Abstract;
using LongDistanceService.Domain.Services.Identity;
using LongDistanceService.Domain.Services.Identity.Abstract;
using LongDistanceService.Domain.Services.Utils;
using LongDistanceService.Domain.Services.Utils.Abstract;
using LongDistanceService.Shared.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.Services;

public static class LongDistanceServiceExtensions
{
    public static IServiceCollection AddLongDistanceEntityServices(this IServiceCollection @this) =>
        @this
            .AddScoped<IUserService, UserService>()
            .AddScoped<IProfileService, ProfileService>()
            .AddScoped<IVehicleService, VehicleService>();

    public static IServiceCollection AddLongDistanceUtilServices(this IServiceCollection @this)
    {
        var reader = new EmailHtmlCodeReader();
        var templates = reader.ReadAndParseHtmlTemplates(
            Path.Join(Directory.GetCurrentDirectory(), @"EmailTemplates\CodeReasons"));


        return @this
            .AddSingleton<IHtmlCodeTemplateFactory>(new HtmlCodeTemplateFactory(templates))
            .AddScoped<IEmailSender, EmailSender>()
            .AddScoped<IPasswordHasher, BCryptPasswordHasher>();
    }


    public static IServiceCollection AddLongDistanceIdentityServices(this IServiceCollection @this) =>
        @this
            .AddScoped<IIdentityService, IdentityService>()
            .AddTransient<IAccessTokenService, AccessTokenService>()
            .AddTransient<ITwoFactorCodeService, TwoFactorCodeService>();
}