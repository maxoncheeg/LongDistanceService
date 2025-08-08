using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.CQRS.Responses.Personals;

public class SlimLegalResponse : ISlimLegal
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
}