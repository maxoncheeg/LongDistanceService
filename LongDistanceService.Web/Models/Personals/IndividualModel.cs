using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Web.Models.Personals;

public class IndividualModel : IIndividual
{
    public int Id { get; set; }
    [Required, MaxLength(32, ErrorMessage = "Максимальная длина 32")]
    public string Name { get; set; } = string.Empty;
    [Required, MaxLength(32, ErrorMessage = "Максимальная длина 32")]
    public string Surname { get; set; } = string.Empty;
    [Required, MaxLength(32, ErrorMessage = "Максимальная длина 32")]
    public string Patronymic { get; set; } = string.Empty;
    [Required, RegularExpression(@"^8\d{10}$", ErrorMessage = "Пример: 89831335714")]
    public string Phone { get; set; } = string.Empty;

    public DateOnly PassportDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required, RegularExpression(@"^\d{10}$", ErrorMessage = "Пример: 1111223344")]
    public string PassportSeries { get; set; } = string.Empty;
    
    [Required, MaxLength(64, ErrorMessage = "Максимальная длина 64")]
    public string PassportIssued { get; set; } = string.Empty;
}