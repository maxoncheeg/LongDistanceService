using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.AuthProviders;

public record AddAuthProviderRequest(int UserId, string ProviderName, string ProviderId) : IRequest<bool>;