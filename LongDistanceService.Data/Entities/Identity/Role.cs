using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Data.Entities.Identity;

public class Role : IEntity
{
    public int Id { get; set; }
    public UserRole Type { get; set; }
    public IList<User> Users { get; set; } = [];
}