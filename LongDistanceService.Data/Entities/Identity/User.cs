using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Data.Entities.Personals;

namespace LongDistanceService.Data.Entities.Identity;

public class User : IEntity
{
    public int Id { get; set; }
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;

    public IList<Application> Applications { get; set; } = null!;
    public IList<ApplicationMessage> ApplicationMessages { get; set; } = null!;
    public IList<MenuTabRight> Rights { get; set; } = null!;
}