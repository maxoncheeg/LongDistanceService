namespace LongDistanceService.Domain.Services.Utils.Abstract;

public interface IWordSqlConverter
{
    public Task<Stream?> ConvertTableToWordAsync(string tableName);
}