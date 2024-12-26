using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.Models.Options;

public class LegalSearchOptions
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string TIN { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string OfficeNumber { get; set; } = string.Empty;
}