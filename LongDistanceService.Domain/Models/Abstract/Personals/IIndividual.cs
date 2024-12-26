namespace LongDistanceService.Domain.Models.Abstract.Personals;

public interface IIndividual
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Phone { get; set; }
    public DateOnly PassportDate { get; set; }
    public string PassportSeries { get; set; }
    public string PassportIssued { get; set; }
}