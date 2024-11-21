using LongDistanceService.Domain.CQRS.Responses.Sql;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Sql;

public record SelectSqlRequest(string Query) : IRequest<SqlSelectResponse>;