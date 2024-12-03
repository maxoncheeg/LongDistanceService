namespace LongDistanceService.Domain.Services.Abstract;

public interface IExcelSqlConverter
{
    public Task<Stream?> ConvertTableToExcelAsync(string tableName);
}