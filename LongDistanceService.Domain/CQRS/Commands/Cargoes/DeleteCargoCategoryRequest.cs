using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Cargoes;

public record DeleteCargoCategoryRequest(int Id) : IRequest<bool>;