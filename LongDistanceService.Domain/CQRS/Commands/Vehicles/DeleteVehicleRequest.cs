using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Vehicles;

public record DeleteVehicleRequest(int Id) : IRequest;