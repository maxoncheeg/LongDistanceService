namespace LongDistanceService.Domain.Models.Abstract.AuthProviders;

public interface IAuthProvider
{
    public int UserId { get; }
    public string ProviderName { get; }
    public string ProviderId { get; }
}