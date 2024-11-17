using System.Threading.Tasks;

namespace LongDistanceService.Web.Services.Abstract;

public interface IIdentityService
{
    public Task<int?> SignInAsync(string login, string password);
    public Task<bool> RefreshSignInAsync(string refreshToken, string expiredToken);
    public void AddRefreshToken(int id, string login);
    public Task<string?> ExtractTokenAsync();
    public string? ExtractRefreshToken();
    public Task<bool> SignOutAsync();
}