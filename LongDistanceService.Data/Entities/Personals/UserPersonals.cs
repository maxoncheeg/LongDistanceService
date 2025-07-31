using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Data.Entities.Personals;

public class UserPersonals
{
    public int UserId { get; set; }
    public int PersonalId { get; set; }
    public ClientTypes PersonalType { get; set; }
    public User User { get; set; }
}