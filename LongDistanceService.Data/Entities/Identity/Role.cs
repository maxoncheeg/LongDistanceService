using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Data.Entities.Identity;

public class Role : IEntity
{
    public int Id { get; set; }
    public Roles Type { get; set; }
    public IList<UserRole> UserRoles { get; set; } = [];
}