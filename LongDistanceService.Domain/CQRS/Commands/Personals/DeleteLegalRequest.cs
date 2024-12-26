using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Personals;

public record DeleteLegalRequest(int Id) : IRequest<bool>;