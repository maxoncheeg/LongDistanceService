using LongDistanceService.Web.Models.Scenario.Abstract;

namespace LongDistanceService.Web.Services.Abstract;

public interface IScenarioService
{
    public Task<IAuthResult?> TryAuthenticateUserAsync(string returnUrl = "", bool tryRefreshToken = true, bool redirectToLogin = false);
}