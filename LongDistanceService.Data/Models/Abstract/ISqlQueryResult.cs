namespace LongDistanceService.Data.Models.Abstract;

public interface ISqlQueryResult
{
    public string Message { get; set; }
    public IList<string> Headers { get; set; }
    public IList<IList<string>> Rows { get; set; }
}