using System.Reflection;
using LongDistanceService.Api.Middlewares;
using LongDistanceService.Api.Settings;
using LongDistanceService.Api.Settings.Options;
using LongDistanceService.Domain.Services.Options;
using LongDistanceService.Shared.DependencyInjection.Data;
using LongDistanceService.Shared.DependencyInjection.MediatR;
using LongDistanceService.Shared.DependencyInjection.Services;

var builder = WebApplication.CreateBuilder(args);

var jwtOptions = builder.Configuration
    .GetSection("JwtOptions")
    .Get<JwtOptions>();
if (jwtOptions == null) throw new ApplicationException("JwtOptions == null");
builder.Services.AddSingleton(jwtOptions);

var emailOptions = builder.Configuration
    .GetSection("EmailOptions")
    .Get<EmailOptions>();
if (emailOptions == null) throw new ApplicationException("EmailOptions == null");
builder.Services.AddSingleton(emailOptions);

builder.Services.AddHttpContextAccessor();
builder.Services
    .AddControllers()    
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });;

builder.Services
    .AddSwagger()
    .AddOpenTelemetryForGrafana(["ControllerMeter"])
    .AddLongDistanceUtilServices()
    .AddLongDistanceIdentityServices()
    .AddLongDistanceEntityServices()
    .AddApiServices();

builder.Services.AddJwtTokens(jwtOptions)
    .AddOAuthVk(builder.Configuration.GetSection("OAuth:VK").Get<OAuthVkOptions>()!)
    .AddOAuthOdnoklassniki(builder.Configuration.GetSection("OAuth:OK").Get<OAuthOkOptions>()!)
    .AddCookie();

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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
    options.AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("/", async context => context.Response.Redirect("/swagger"));

//app.Urls.Add("http://192.168.0.148:80");
app.Run();