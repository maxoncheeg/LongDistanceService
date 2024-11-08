using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Drivers;

public class Driver : AbstractPersonalEntity
{
    public int CategoryId { get; set; }
    public DriverCategory Category { get; set; } = new();
    public string EmployeeNumber { get; set; } = String.Empty;
    public string Class { get; set; } = String.Empty;
    public int BirthYear { get; set; }
    public int Experience { get; set; }
    public IList<OrderDriver> OrderDrivers { get; set; } = new List<OrderDriver>();
}