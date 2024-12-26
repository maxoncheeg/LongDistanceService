using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Vehicles;

public record DeleteModelRequest(int Id) : IRequest<bool>;