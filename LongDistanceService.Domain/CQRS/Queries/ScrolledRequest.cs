using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries;

public record ScrolledRequest<T> : IRequest<IList<T>>, ISearchable
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 10;
    public string? Search { get; set; }
}