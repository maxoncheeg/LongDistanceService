using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.TwoFactor;
using LongDistanceService.Domain.CQRS.Responses.TwoFactors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.TwoFactor;

public class GetTwoFactorSecretHandler(IApplicationDbContext context)
    : IRequestHandler<GetLastTwoFactorSecretRequest, TwoFactorSecretResponse?>
{
    public async Task<TwoFactorSecretResponse?> Handle(GetLastTwoFactorSecretRequest request,
        CancellationToken cancellationToken)
    {
        var secret = await context.TwoFactorSecrets
            .OrderByDescending(s => s.Id)
            .Where(s => s.UserId == request.UserId && s.CodeReason == request.CodeReason)
            .Select(s => new TwoFactorSecretResponse
            {
                CodeReason = s.CodeReason,
                Expires = s.Expires,
                UserId = s.UserId,
                Secret = s.Secret,
                Id = s.Id
            })
            .FirstOrDefaultAsync(cancellationToken);

        return secret;
    }
}