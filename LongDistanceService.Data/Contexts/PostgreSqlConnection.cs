using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Models;
using LongDistanceService.Data.Models.Abstract;
using Npgsql;

namespace LongDistanceService.Data.Contexts;

public class PostgreSqlConnection : ISqlConnection
{
    private readonly string _connectionString;

    public PostgreSqlConnection(string connectionString)
    {
        _connectionString =
            new NpgsqlConnectionStringBuilder(
                "host=localhost;port=5433;username=postgres;password=33424324;database=lds_db").ToString();
    }

    public async Task<ISqlQueryResult> SqlQueryAsync(string query)
    {
        if (!query.Trim().StartsWith("select", StringComparison.InvariantCultureIgnoreCase))
            return new SqlQueryResult() { Message = "incorrect command" };

        List<string> headers = [];
        List<Type> types = [];
        List<IList<string>> rows = [];
        await using var connection = new NpgsqlConnection(_connectionString);

        try
        {
            await connection.OpenAsync();
            await using var command = new NpgsqlCommand(query, connection);
            await using var reader = await command.ExecuteReaderAsync();
            
            
            for (int i = 0; i < reader.FieldCount; i++)
            {
                headers.Add(reader.GetName(i));
                types.Add(reader.GetFieldType(i));
            }
            
            while (await reader.ReadAsync())
            {
                List<string> row = [];
                for (int i = 0; i < reader.FieldCount; i++)
                    row.Add(reader.GetValue(i).ToString() ?? "null");
                rows.Add(row);
            }

            await connection.CloseAsync();
        }
        catch (PostgresException exception)
        {
            await connection.CloseAsync();
            return new SqlQueryResult() { Message = exception.MessageText };
        }

        return new SqlQueryResult()
        {
            Headers = headers,
            HeaderTypes = types,
            Rows = rows
        };
    }

    public async Task<ISqlCommandResult> SqlCommandAsync(string query)
    {
        if (query.Trim().StartsWith("select", StringComparison.InvariantCultureIgnoreCase))
            return new SqlCommandResult() { Message = "incorrect command" };

        int result = -1;
        await using var connection = new NpgsqlConnection(_connectionString);

        try
        {
            await connection.OpenAsync();
            await using var command = new NpgsqlCommand(query, connection);
            result = await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }
        catch (PostgresException exception)
        {
            await connection.CloseAsync();
            return new SqlCommandResult() { Message = exception.MessageText };
        }

        return new SqlCommandResult()
        {
            Result = result
        };
    }
}