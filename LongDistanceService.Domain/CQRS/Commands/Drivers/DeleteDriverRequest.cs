using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Drivers;

public record DeleteDriverRequest(int Id) : IRequest<bool>;