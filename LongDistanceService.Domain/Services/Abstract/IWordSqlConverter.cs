namespace LongDistanceService.Domain.Services.Abstract;

public interface IWordSqlConverter
{
    public Task<Stream?> ConvertTableToWordAsync(string tableName);
}