namespace LongDistanceService.Domain.Models.Abstract.Drivers;

public interface IDriverInfo
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string CategoryName { get; set; }
    public bool InWork { get; set; }
    public int Experience { get; set; }
    public string EmployeeNumber { get; set; }
}