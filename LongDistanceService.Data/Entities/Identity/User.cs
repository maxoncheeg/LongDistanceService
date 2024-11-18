using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Identity;

public class User : IEntity
{
    public int Id { get; set; }
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;

    public IList<MenuTabRight> Rights { get; set; } = null!;
}