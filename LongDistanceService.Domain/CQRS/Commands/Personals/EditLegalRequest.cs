using LongDistanceService.Domain.Models.Abstract.Personals;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Personals;

public class EditLegalRequest : IRequest<bool>, IEditLegal
{
    public int Id { get; set; }
    public int BankId { get; set; }
    public int CityId { get; set; }
    public int StreetId { get; set; }
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