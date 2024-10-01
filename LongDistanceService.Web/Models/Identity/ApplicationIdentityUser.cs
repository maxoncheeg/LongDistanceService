using LongDistanceService.Shared.Services.Identity;

namespace LongDistanceService.Web.Models.Identity;

public class ApplicationIdentityUser : IIdentityUser
{
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}