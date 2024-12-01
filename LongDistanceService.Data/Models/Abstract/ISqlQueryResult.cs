namespace LongDistanceService.Data.Models.Abstract;

public interface ISqlQueryResult
{
    public string Message { get; set; }
    public IList<string> Headers { get; }
    public IList<Type> HeaderTypes { get; }
    public IList<IList<string>> Rows { get; }
}