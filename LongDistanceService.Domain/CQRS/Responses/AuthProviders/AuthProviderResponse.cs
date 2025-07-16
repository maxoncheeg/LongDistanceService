using LongDistanceService.Domain.Models.Abstract.AuthProviders;

namespace LongDistanceService.Domain.CQRS.Responses.AuthProviders;

public record AuthProviderResponse(int UserId, string ProviderName, string ProviderId) : IAuthProvider;