using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Drivers;

public class Driver : AbstractPersonalEntity
{
    public int CategoryId { get; set; }
    public DriverCategory Category { get; set; }
    public string Number { get; set; }
    public string Class { get; set; }
    public int BirthYear { get; set; }
    public int Experience { get; set; }
}