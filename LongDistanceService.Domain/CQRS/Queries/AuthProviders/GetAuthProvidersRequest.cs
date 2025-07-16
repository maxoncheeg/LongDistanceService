using LongDistanceService.Domain.CQRS.Responses.AuthProviders;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.AuthProviders;

public record GetAuthProvidersRequest(int UserId, string ProviderName = "") : IRequest<IList<AuthProviderResponse>?>;