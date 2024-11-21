namespace LongDistanceService.Data.Models.Abstract;

public interface ISqlCommandResult
{
    public string Message { get; set; }
    public int Result { get; set; }
}