using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Models.Abstract.Applications;

public interface IApplicationInfo
{
    public int Id { get; }
    public DateOnly Created { get; }
    public DateTime? LastMessageDate { get; }
    public ApplicationState Status { get; }
}