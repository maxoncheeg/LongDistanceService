using LongDistanceService.Domain.CQRS.Responses.AuthProviders;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.AuthProviders;

public record GetAuthProviderByIdRequest(string ProviderName, string ProviderId) : IRequest<AuthProviderResponse?>;