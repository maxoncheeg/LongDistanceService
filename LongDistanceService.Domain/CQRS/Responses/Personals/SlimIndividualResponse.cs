using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.CQRS.Responses.Personals;

public class SlimIndividualResponse : ISlimIndividual
{
    public int Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
}