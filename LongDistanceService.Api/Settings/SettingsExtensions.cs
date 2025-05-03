using LongDistanceService.Api.Services;
using LongDistanceService.Api.Services.Abstract;
using LongDistanceService.Domain.Services.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

    public static IServiceCollection AddJwtTokens(this IServiceCollection @this, JwtOptions jwtOptions)
    {
        @this.AddAuthentication(options =>
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
                    IssuerSigningKey = jwtOptions.SymmetricSecurityKey
                };
            });

        return @this;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection @this)
    {
        return @this.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    public static IServiceCollection AddApiServices(this IServiceCollection @this) =>
        @this.AddTransient<ITokenManager, TokenManager>();
}