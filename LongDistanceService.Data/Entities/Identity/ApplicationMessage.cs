using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Identity;

public class ApplicationMessage : IEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int UserId { get; set; }
    public int? AnsweredAt { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }


    public Application Application { get; set; } = null!;
    public User User { get; set; } = null!;
}