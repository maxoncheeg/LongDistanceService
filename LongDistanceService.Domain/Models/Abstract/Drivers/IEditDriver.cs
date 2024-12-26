namespace LongDistanceService.Domain.Models.Abstract.Drivers;

public interface IEditDriver
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public int CategoryId { get; set; }
    public string EmployeeNumber { get; set; }
    public string Class { get; set; }
    public int BirthYear { get; set; }
    public int Experience { get; set; }
}