namespace LongDistanceService.Web.Services.Abstract;

public interface IAuthorizationService
{
    public Task<bool> SignInAsync(string login, string password);
    public Task<bool> SignOutAsync();
}