using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Commands.AuthProviders;
using MediatR;

namespace LongDistanceService.Data.Handlers.Commands.AuthProviders;

public class AuthProviderHandler(IApplicationDbContext context) : IRequestHandler<AddAuthProviderRequest, bool>
{
    public async Task<bool> Handle(AddAuthProviderRequest request, CancellationToken cancellationToken)
    {
        if (request.UserId <= 0 || string.IsNullOrEmpty(request.ProviderName) ||
            string.IsNullOrEmpty(request.ProviderId))
            return false;

        AuthProvider provider = new AuthProvider
            { UserId = request.UserId, ProviderName = request.ProviderName, ProviderId = request.ProviderId };

        await context.CreateAsync(provider);
        await context.SaveAsync();

        return true;
    }
}