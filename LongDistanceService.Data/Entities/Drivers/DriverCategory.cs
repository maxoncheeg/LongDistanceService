using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Drivers;

public class DriverCategory : AbstractNameEntity
{
    public IList<Driver> Drivers { get; set; } = new List<Driver>();
}