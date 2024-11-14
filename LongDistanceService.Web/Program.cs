using System.Reflection;
using System.Text;
using LongDistanceService.Domain.Services;
using LongDistanceService.Domain.Services.Abstract;
using LongDistanceService.Domain.Services.Options;
using LongDistanceService.Shared.DependencyInjection;
using LongDistanceService.Shared.DependencyInjection.Data;
using LongDistanceService.Shared.DependencyInjection.Identity;
using LongDistanceService.Shared.DependencyInjection.MediatR;
using LongDistanceService.Web.Components;
using LongDistanceService.Web.Services;
using LongDistanceService.Web.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

#region cookie&identity


var jwtOptions = builder.Configuration
    .GetSection("JwtOptions")
    .Get<JwtOptions>();

builder.Services.AddSingleton(jwtOptions);

//builder.Services.AddSingleton<IIdentitySchemeConstants>(identitySchemeConstants);

builder.Services
    .AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opts =>
    {
        opts.SaveToken = true;
        //convert the string signing key to byte array
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = jwtOptions.SymmetricSecurityKey
        };
    }).AddCookie();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IAccessTokenService, AccessTokenService>().AddHttpContextAccessor()
    .AddScoped<IAuthorizationService, AuthorizationService>()
    .AddSingleton<TokenValidationParameters>(new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        IssuerSigningKey = jwtOptions.SymmetricSecurityKey
    })
    .AddScoped<IPasswordHasher, BCryptPasswordHasher>();


#endregion

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddPostgresDatabase(connectionString);
//builder.Services.AddApplicationIdentity().AddCascadingAuthenticationState();
builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
    .AddMediatRHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();