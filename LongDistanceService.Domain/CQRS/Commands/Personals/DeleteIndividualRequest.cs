using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Personals;

public record DeleteIndividualRequest(int Id) : IRequest<bool>;