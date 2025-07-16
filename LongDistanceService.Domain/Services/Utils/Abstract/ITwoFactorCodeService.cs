using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Services.Utils.Abstract;

public interface ITwoFactorCodeService
{
    public Task<string?> GenerateTwoFactorCodeAsync(int userId, CodeReason codeReason);
    public Task<CodeValidationResult> ValidateTwoFactorCodeAsync(int userId, string code, CodeReason codeReason);
}