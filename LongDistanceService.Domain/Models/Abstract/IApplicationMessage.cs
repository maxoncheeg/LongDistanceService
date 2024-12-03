namespace LongDistanceService.Domain.Models.Abstract;

public interface IApplicationMessage
{
    public int Id { get; }
    public int ApplicationId { get; }
    public int UserId { get; }
    public int? AnsweredAt { get; }
    public string Text { get; }
    public DateTime Timestamp { get; }
}