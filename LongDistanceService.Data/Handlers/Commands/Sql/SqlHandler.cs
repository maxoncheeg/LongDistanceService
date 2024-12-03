using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Commands.Sql;
using LongDistanceService.Domain.CQRS.Responses.Sql;
using MediatR;

namespace LongDistanceService.Data.Handlers.Commands.Sql;

public class SqlHandler(ISqlConnection connection) : IRequestHandler<SelectSqlRequest, SqlSelectResponse>, IRequestHandler<CommandSqlRequest, SqlCommandResponse>
{
    public async Task<SqlSelectResponse> Handle(SelectSqlRequest request, CancellationToken cancellationToken)
    {
        var result = await connection.SqlQueryAsync(request.Query);

        return new SqlSelectResponse()
        {
            Message = result.Message,
            Headers = result.Headers,
            HeaderTypes = result.HeaderTypes,
            Rows = result.Rows
        };
    }

    public async Task<SqlCommandResponse> Handle(CommandSqlRequest request, CancellationToken cancellationToken)
    {
        var result = await connection.SqlCommandAsync(request.Query);

        return new SqlCommandResponse()
        {
            Message = result.Message,
            Result = result.Result
        };
    }
}