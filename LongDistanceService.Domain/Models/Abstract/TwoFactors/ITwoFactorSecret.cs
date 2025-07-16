using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Models.Abstract.TwoFactors;

public interface ITwoFactorSecret
{
    public int Id { get; set; }
    public string Secret { get; set; }
    public CodeReason CodeReason { get; set; }
    public int UserId { get; set; }
    public DateTime Expires { get; set; }
}