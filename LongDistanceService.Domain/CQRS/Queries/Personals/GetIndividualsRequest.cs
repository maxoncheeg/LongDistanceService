using LongDistanceService.Domain.CQRS.Responses.Personals;
using LongDistanceService.Domain.Models.Options;

namespace LongDistanceService.Domain.CQRS.Queries.Personals;

public record GetIndividualsRequest : ScrolledRequest<IndividualResponse>
{
    public IndividualSearchOptions? Options { get; set; }
}