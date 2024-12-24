using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Drivers;

namespace LongDistanceService.Web.Models.Drivers;

public class DriverModel : IEditDriver
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Требуется имя")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Требуется фамилия")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Требуется отчество")]
    public string Patronymic { get; set; }

    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Требуется табельный номер"),
     RegularExpression(@"^\d{4}$", ErrorMessage = "Табельный номер должен быть в формате: 1234")]
    public string EmployeeNumber { get; set; } = "0000";

    [Required(ErrorMessage = "Требуется класс")]
    public string Class { get; set; } = "0";

    [Required(ErrorMessage = "Требуется год рождения"),
     Range(1800, 2025, ErrorMessage = "Введите дату рождения от 1800 года до 2025 года")]
    public int BirthYear { get; set; }
    
    [Required(ErrorMessage = "Требуется опыт езды"),
     Range(0, 100, ErrorMessage = "Введите опыт в промежутке от 0 до 100 лет")]
    public int Experience { get; set; }
}