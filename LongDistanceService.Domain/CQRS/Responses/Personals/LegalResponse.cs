using LongDistanceService.Domain.Models.Abstract.Addresses;
using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.CQRS.Responses.Personals;

public class LegalResponse : ILegal
{
    public int Id { get; set; }
    public IBank Bank { get; set; } = null!;
    public ICity City { get; set; } = null!;
    public IStreet Street { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string TIN { get; set; } = string.Empty;
    public string Account { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string OfficeNumber { get; set; } = string.Empty;
}