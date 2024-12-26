using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Identity;

public class Role : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<User> Users { get; set; } = [];
    public IList<MenuTabRight> MenuTabRights { get; set; } = [];
}