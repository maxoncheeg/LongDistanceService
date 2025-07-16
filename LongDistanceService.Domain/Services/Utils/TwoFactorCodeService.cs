using LongDistanceService.Domain.CQRS.Commands.TwoFactor;
using LongDistanceService.Domain.CQRS.Queries.TwoFactor;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Services.Utils.Abstract;
using MediatR;
using TwoFactorAuthNet;

namespace LongDistanceService.Domain.Services.Utils;

public class TwoFactorCodeService(
    IMediator mediator,
    int expirationTimeInSeconds = 60 * 5,
    int secretBits = 180)
    : ITwoFactorCodeService
{
    private readonly TwoFactorAuth _twoFactorAuth = new("lds", period: expirationTimeInSeconds);

    public async Task<string?> GenerateTwoFactorCodeAsync(int userId, CodeReason codeReason)
    {
        var secret = _twoFactorAuth.CreateSecret(secretBits);
        var code = _twoFactorAuth.GetCode(secret);

        var result = await mediator.Send(new CreateTwoFactorSecretRequest()
        {
            UserId = userId,
            CodeReason = codeReason,
            Expires = DateTime.UtcNow.AddSeconds(expirationTimeInSeconds),
            Secret = secret
        });

        return result ? code : null;
    }

    public async Task<CodeValidationResult> ValidateTwoFactorCodeAsync(int userId, string code, CodeReason codeReason)
    {
        var twoFactorSecret = await mediator.Send(new GetLastTwoFactorSecretRequest(userId, codeReason));

        if (twoFactorSecret == null)
            return CodeValidationResult.InvalidCode;
        if (twoFactorSecret.Expires < DateTime.UtcNow)
            return CodeValidationResult.Expired;

        return _twoFactorAuth.VerifyCode(twoFactorSecret.Secret, code)
            ? CodeValidationResult.Success
            : CodeValidationResult.InvalidCode;
    }
}