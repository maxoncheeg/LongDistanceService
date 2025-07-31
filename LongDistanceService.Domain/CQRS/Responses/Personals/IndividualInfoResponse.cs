using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Domain.CQRS.Responses.Personals;

public class IndividualInfoResponse : IIndividualInfo
{
    public int Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
}