namespace LongDistanceService.Domain.CQRS.Responses.Sql;

public class SqlCommandResponse
{
    public string Message { get; set; } = string.Empty;
    public int Result { get; set; } = -1;
}