namespace LongDistanceService.Domain.Services.Utils.Abstract;

public interface IExcelSqlConverter
{
    public Task<Stream?> ConvertTableToExcelAsync(string tableName);
}