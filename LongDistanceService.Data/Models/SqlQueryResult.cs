using LongDistanceService.Data.Models.Abstract;

namespace LongDistanceService.Data.Models;

public class SqlQueryResult : ISqlQueryResult
{
    public string Message { get; set; } = string.Empty;
    public IList<string> Headers { get; set; } = [];
    public IList<Type> HeaderTypes { get; set; } = [];
    public IList<IList<string>> Rows { get; set; } = [];
}