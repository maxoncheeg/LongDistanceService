using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Cargoes;

public record DeleteCargoRequest(int Id) : IRequest<bool>;