namespace LongDistanceService.Domain.CQRS.Queries;

public interface ISearchable
{
    public string? Search { get; set; }
}