using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.CQRS.Responses.Personals;

public class IndividualResponse : IIndividual
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateOnly PassportDate { get; set; }
    public string PassportSeries { get; set; } = string.Empty;
    public string PassportIssued { get; set; } = string.Empty;
}