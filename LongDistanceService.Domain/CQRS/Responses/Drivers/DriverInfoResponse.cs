using LongDistanceService.Domain.Models.Abstract.Drivers;

namespace LongDistanceService.Domain.CQRS.Responses.Drivers;

public class DriverInfoResponse : IDriverInfo
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public bool InWork { get; set; }
    public int Experience { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string EmployeeNumber { get; set; } = string.Empty;
}