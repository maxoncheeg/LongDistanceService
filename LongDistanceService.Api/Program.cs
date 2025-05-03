using System.Reflection;
using LongDistanceService.Api.Middlewares;
using LongDistanceService.Api.Settings;
using LongDistanceService.Domain.Services.Options;
using LongDistanceService.Shared.DependencyInjection.Data;
using LongDistanceService.Shared.DependencyInjection.MediatR;
using LongDistanceService.Shared.DependencyInjection.Services;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);

var jwtOptions = builder.Configuration
    .GetSection("JwtOptions")
    .Get<JwtOptions>();
if (jwtOptions == null) throw new ApplicationException("JwtOptions == null");
builder.Services.AddSingleton(jwtOptions);


builder.Services.AddHttpContextAccessor();

builder.Services
    .AddSwagger()
    .AddOpenTelemetryForGrafana(["ControllerMeter"])
    .AddJwtTokens(jwtOptions)
    .AddLongDistanceServices()
    .AddApiServices();

builder.Services
    .AddControllers();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddPostgresDatabase(connectionString).AddPostresConnection(connectionString);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
    .AddMediatRHandlers();

var app = builder.Build();

app.UseMiddleware<TokenMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
    });
    app.UseSwaggerUI();
}

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();


app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowCredentials();
});


app.MapControllers();

app.Urls.Add("http://localhost:80");
app.Run();