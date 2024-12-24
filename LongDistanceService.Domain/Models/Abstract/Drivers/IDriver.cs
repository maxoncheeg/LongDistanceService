namespace LongDistanceService.Domain.Models.Abstract.Drivers;

public interface IDriver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public IDriverCategory Category { get; set; }
    public string EmployeeNumber { get; set; }
    public string Class { get; set; }
    public int BirthYear { get; set; }
    public int Experience { get; set; }
}