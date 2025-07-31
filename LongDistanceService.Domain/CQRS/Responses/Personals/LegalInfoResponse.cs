using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.CQRS.Responses.Personals;

public class LegalInfoResponse : ILegalInfo
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
}