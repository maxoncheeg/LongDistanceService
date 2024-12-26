using LongDistanceService.Domain.CQRS.Responses.Personals;
using LongDistanceService.Domain.Models.Options;

namespace LongDistanceService.Domain.CQRS.Queries.Personals;

public record GetLegalsRequest : ScrolledRequest<LegalResponse>
{
    public LegalSearchOptions? Options { get; set; }
}