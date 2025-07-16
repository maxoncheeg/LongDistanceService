using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Data.Entities.Identity;

public class TwoFactorSecret : IEntity
{
    public int Id { get; set; }
    public string Secret { get; set; }
    public CodeReason CodeReason { get; set; }
    public DateTime Expires { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}