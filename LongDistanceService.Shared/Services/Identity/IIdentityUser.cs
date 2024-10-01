namespace LongDistanceService.Shared.Services.Identity;

public interface IIdentityUser
{
    public string Password { get; set; }
    public string Email { get; set; }
}