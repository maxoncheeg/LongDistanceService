using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.TwoFactors;

namespace LongDistanceService.Domain.CQRS.Responses.TwoFactors;

public class TwoFactorSecretResponse : ITwoFactorSecret
{
    public int Id { get; set; }
    public string Secret { get; set; } = string.Empty;
    public CodeReason CodeReason { get; set; }
    public int UserId { get; set; }
    public DateTime Expires { get; set; }
}