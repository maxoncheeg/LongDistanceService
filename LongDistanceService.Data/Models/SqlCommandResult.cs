using LongDistanceService.Data.Models.Abstract;

namespace LongDistanceService.Data.Models;

public class SqlCommandResult : ISqlCommandResult
{
    public string Message { get; set; } = string.Empty;
    public int Result { get; set; }
}