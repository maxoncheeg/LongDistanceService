using LongDistanceService.Domain.Models.Abstract.Drivers;

namespace LongDistanceService.Domain.CQRS.Responses.Drivers;

public class DriverResponse : IDriver
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public IDriverCategory Category { get; set; } = null!;
    public string EmployeeNumber { get; set; } = string.Empty;
    public string Class { get; set; } = String.Empty;
    public int BirthYear { get; set; }
    public int Experience { get; set; }
}