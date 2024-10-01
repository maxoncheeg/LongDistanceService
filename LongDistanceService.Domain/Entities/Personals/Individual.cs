using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Personals;

public class Individual : AbstractPersonalEntity
{
    public string Phone { get; set; }
    public string PassportSeries { get; set; }
    public DateTime PassportDate { get; set; }
    public string PassportIssued { get; set; }
}