namespace LongDistanceService.Domain.CQRS.Responses.Sql;

public class SqlSelectResponse
{
    public string Message { get; set; } = string.Empty;
    public IList<string> Headers { get; set; } = [];
    public IList<Type> HeaderTypes { get; set; } = [];
    public IList<IList<string>> Rows { get; set; } = [];
}