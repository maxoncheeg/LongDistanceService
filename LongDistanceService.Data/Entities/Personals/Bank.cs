using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Personals;

public class Bank : AbstractNameEntity
{
    public IList<Legal> Legals { get; set; } = new List<Legal>();
}