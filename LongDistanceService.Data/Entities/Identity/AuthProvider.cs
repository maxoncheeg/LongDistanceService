using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Identity;

public class AuthProvider
{
    public int UserId { get; set; }
    public string ProviderId { get; set; } = string.Empty;
    public string ProviderName { get; set; } = string.Empty;
    
    public User User { get; set; } = null!;
}