using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Commands.TwoFactor;
using MediatR;

namespace LongDistanceService.Data.Handlers.Commands.TwoFactor;

public class TwoFactorHandler(IApplicationDbContext context) : IRequestHandler<CreateTwoFactorSecretRequest, bool>
{
    public async Task<bool> Handle(CreateTwoFactorSecretRequest request, CancellationToken cancellationToken)
    {
        var secret = new TwoFactorSecret()
        {
            Secret = request.Secret,
            CodeReason = request.CodeReason,
            UserId = request.UserId,
            Expires = request.Expires
        };

        try
        {
            await context.CreateAsync(secret);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }
}