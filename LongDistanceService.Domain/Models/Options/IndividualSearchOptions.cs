using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.Models.Options;

public class IndividualSearchOptions
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Phone { get; set; }
    public DateOnly PassportDate { get; set; }
    public string PassportSeries { get; set; }
    public string PassportIssued { get; set; }
}