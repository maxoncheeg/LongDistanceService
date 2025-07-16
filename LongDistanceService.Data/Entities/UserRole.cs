using LongDistanceService.Data.Entities.Identity;

namespace LongDistanceService.Data.Entities;

public class UserRole
{
    public int RoleId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Role Role { get; set; }
}