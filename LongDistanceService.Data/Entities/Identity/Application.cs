using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Data.Entities.Identity;

public class Application : IEntity
{
    public int Id { get; set; }
    public DateOnly Created { get; set; }
    public ApplicationState Status { get; set; }
    public int CreatorId { get; set; }
    
    public User User { get; set; } = null!;
    public IList<ApplicationMessage> Messages { get; set; } = null!;
}