using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Models.Abstract;

public interface IApplication
{
    public int Id { get; }
    public DateOnly Created { get; }
    public ApplicationState Status { get; }
    public int CreatorId { get; }
    public IList<IApplicationMessage> Messages { get; }
}