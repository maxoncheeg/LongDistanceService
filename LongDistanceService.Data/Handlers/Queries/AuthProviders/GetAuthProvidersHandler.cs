using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.AuthProviders;
using LongDistanceService.Domain.CQRS.Responses.AuthProviders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.AuthProviders;

public class GetAuthProvidersHandler(IApplicationDbContext context)
    : IRequestHandler<GetAuthProvidersRequest, IList<AuthProviderResponse>?>
        , IRequestHandler<GetAuthProviderByIdRequest, AuthProviderResponse?>
{
    public async Task<IList<AuthProviderResponse>?> Handle(GetAuthProvidersRequest request,
        CancellationToken cancellationToken)
    {
        var query = context.AuthProviders.Where(a => a.UserId == request.UserId);

        if (!string.IsNullOrEmpty(request.ProviderName))
        {
            query = query.Where(a => a.ProviderName == request.ProviderName);
        }

        return await query.Select(a => new AuthProviderResponse(a.UserId, a.ProviderName, a.ProviderId))
            .ToListAsync(cancellationToken);
    }

    public async Task<AuthProviderResponse?> Handle(GetAuthProviderByIdRequest request,
        CancellationToken cancellationToken)
    {
        return await context.AuthProviders
            .Where(a => a.ProviderName == request.ProviderName && a.ProviderId == request.ProviderId)
            .Select(a => new AuthProviderResponse(a.UserId, a.ProviderName, a.ProviderId))
            .SingleOrDefaultAsync(cancellationToken);
    }
}