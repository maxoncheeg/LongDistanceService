using LongDistanceService.Data.Models.Abstract;

namespace LongDistanceService.Data.Contexts.Abstract;

public interface ISqlConnection
{
    public Task<ISqlQueryResult> SqlQueryAsync(string query);
    public Task<ISqlCommandResult> SqlCommandAsync(string query);
}