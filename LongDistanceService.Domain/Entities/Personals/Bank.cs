using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Personals;

public class Bank : AbstractNameEntity
{
    public IList<Legal> Legals { get; set; } = new List<Legal>();
}