using LongDistanceService.Domain.Models.Abstract.AuthProviders;

namespace LongDistanceService.Domain.Models;

public record AuthProvider(int UserId, string ProviderName, string ProviderId) : IAuthProvider;