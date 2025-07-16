using System.Security.Claims;
using AspNet.Security.OAuth.VkId;
using LongDistanceService.Api.Controllers.Routes;
using LongDistanceService.Api.Services;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Api.Settings.Authentication;
using LongDistanceService.Api.Settings.Options;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Services.Identity;
using LongDistanceService.Domain.Services.Identity.Abstract;
using LongDistanceService.Domain.Services.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace LongDistanceService.Api.Settings;

public static class SettingsExtensions
{
    private const string ServiceName = "long_distance_service";

    public static IServiceCollection AddOpenTelemetryForGrafana(this IServiceCollection @this,
        IList<string> metricsNames)
    {
        @this.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(ServiceName))
            .WithTracing(tracing => tracing
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("LongDistanceService.Api"))
                .AddSource("TestController")
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddEntityFrameworkCoreInstrumentation()
                .AddSqlClientInstrumentation()
                .AddOtlpExporter(options =>
                {
                    options.Endpoint = new Uri("http://localhost:4317"); // Endpoint для OTLP
                    options.TimeoutMilliseconds = 5000;
                })
            )
            .WithMetrics(metrics =>
            {
                metrics
                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("LongDistanceService.Api"))
                    .AddAspNetCoreInstrumentation()
                    .AddRuntimeInstrumentation()
                    .AddHttpClientInstrumentation();

                foreach (var metric in metricsNames)
                    metrics.AddMeter("metric");

                metrics.AddPrometheusExporter();
            });

        return @this;
    }

    public static AuthenticationBuilder AddJwtTokens(this IServiceCollection @this, JwtOptions jwtOptions)
    {
        var builder = @this.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                //options.RequireHttpsMetadata = true;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,

                    ValidAudience = jwtOptions.Audience,
                    ClockSkew = jwtOptions.ClockSkew,
                    IssuerSigningKey = jwtOptions.SymmetricSecurityKey,

                    RoleClaimType = ClaimTypes.Role,
                };

                //
                // options.Events = new JwtBearerEvents
                // {
                //     OnAuthenticationFailed = Task.FromResult,
                // };
            });


        var adminPolicy = new AuthorizationPolicy(
            [new RolesAuthorizationRequirement([Roles.Admin.ToString()])],
            [JwtBearerDefaults.AuthenticationScheme]);
        var externalUserPolicy = new AuthorizationPolicy(
            [new ClaimsAuthorizationRequirement(Claims.ExternalUser, [true.ToString()])],
            [JwtBearerDefaults.AuthenticationScheme]);
        var emailVerifiedPolicy = new AuthorizationPolicy(
            [new ClaimsAuthorizationRequirement(Claims.EmailVerified, [true.ToString()])],
            [JwtBearerDefaults.AuthenticationScheme]);

        @this.AddAuthorizationBuilder()
            .AddPolicy(Policies.Admin, adminPolicy)
            .AddPolicy(Policies.ExternalUser, externalUserPolicy)
            .AddPolicy(Policies.EmailVerified, emailVerifiedPolicy)
            .AddPolicy(Policies.CompleteExternalUser,
                policy => policy.Combine(externalUserPolicy).Combine(emailVerifiedPolicy))
            ;

        return builder;
    }

    public static AuthenticationBuilder AddOAuthVk(this AuthenticationBuilder @this, OAuthVkOptions options,
        string name = "vk")
    {
        return @this.AddVkId(name, opt =>
        {
            opt.ClientId = options.AppId;
            opt.ClientSecret = options.AppSecret;
            opt.UsePkce = true;

            opt.CallbackPath = new PathString(ServiceRoutes.Auth.OAuth.Callback(name));

            opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opt.CorrelationCookie = new CookieBuilder()
            {
                HttpOnly = true, MaxAge = TimeSpan.FromMinutes(5), Expiration = TimeSpan.FromMinutes(5),
                SecurePolicy = CookieSecurePolicy.Always
            };

            opt.SaveTokens = true;

            //opt.Fields.Add("uid");
            //opt.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "uid");
        });
    }

    public static AuthenticationBuilder AddOAuthOdnoklassniki(this AuthenticationBuilder @this, OAuthOkOptions options,
        string name = "ok")
    {
        return @this.AddOdnoklassniki(name, opt =>
        {
            opt.ClientId = options.AppId;
            opt.ClientSecret = options.AppSecret;
            opt.PublicSecret = options.PublicSecret;

            opt.CallbackPath = new PathString(ServiceRoutes.Auth.OAuth.Callback(name));

            opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opt.CorrelationCookie = new CookieBuilder()
            {
                HttpOnly = true, MaxAge = TimeSpan.FromMinutes(5), Expiration = TimeSpan.FromMinutes(5),
                SecurePolicy = CookieSecurePolicy.Always
            };

            opt.SaveTokens = true;
        });
    }

    public static IServiceCollection AddSwagger(this IServiceCollection @this)
    {
        return @this.AddSwaggerGen(options => { });
    }

    public static IServiceCollection AddApiServices(this IServiceCollection @this) =>
        @this
            .AddTransient<ITokenManager, TokenManager>()
            .AddTransient<ISecurityService, SecurityService>();
}