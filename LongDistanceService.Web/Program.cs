using System.Reflection;
using LongDistanceService.Shared.DependencyInjection;
using LongDistanceService.Shared.DependencyInjection.Data;
using LongDistanceService.Shared.DependencyInjection.Identity;
using LongDistanceService.Shared.DependencyInjection.MediatR;
using LongDistanceService.Web.Components;
using LongDistanceService.Web.Services.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

#region cookie&identity

var identitySection = builder.Configuration.GetSection("IdentityScheme");
var identitySchemeConstants = new IdentitySchemeConstants(identitySection["Application"] ?? string.Empty,
    identitySection["External"] ?? string.Empty);

builder.Services.AddSingleton<IIdentitySchemeConstants>(identitySchemeConstants);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = identitySchemeConstants.ExternalScheme;
    })
    .AddCookie();

#endregion

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddPostgresDatabase(connectionString);
builder.Services.AddApplicationIdentity().AddCascadingAuthenticationState();
builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())).AddMediatRHandlers();

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
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();