using LongDistanceService.Web.Models.Scenario;
using LongDistanceService.Web.Models.Scenario.Abstract;
using LongDistanceService.Web.Routes;
using LongDistanceService.Web.Services.Abstract;
using Microsoft.AspNetCore.Components;

namespace LongDistanceService.Web.Services;

public class ScenarioService(
    NavigationManager navigation,
    IIdentityService identityService,
    ISecurityService securityService) : IScenarioService
{
    public async Task<IAuthResult?> TryAuthenticateUserAsync(string returnUrl, bool tryRefreshToken, bool redirectToLogin)
    {
        var token = await identityService.ExtractTokenAsync();
        
        if (token != null)
        {
            var result = await securityService.ValidateTokenAsync(token);

            if (result != null)
                return new AuthResult(token, result);
        }
        else
        {
            if (redirectToLogin)
            {
                navigation.NavigateTo($"{ServiceRoutes.Identity.AdminLogin}" + (string.IsNullOrWhiteSpace(returnUrl) ? "" : $"?returnUrl={returnUrl}"));
            }
            
            return null;
        }

        if (tryRefreshToken)
            navigation.NavigateTo($"{ServiceRoutes.Identity.RefreshToken}" + (string.IsNullOrWhiteSpace(returnUrl) ? "" : $"?returnUrl={returnUrl}"));

        return null;
    }
}