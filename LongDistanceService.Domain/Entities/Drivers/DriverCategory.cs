using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Drivers;

public class DriverCategory : AbstractNameEntity
{
    public IList<Driver> Drivers { get; set; } = new List<Driver>();
}