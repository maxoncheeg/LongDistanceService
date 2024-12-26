using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Sql;

public record UpdateReferenceRequest(string Name, int? ForeignKey, int? Id) : IRequest;