using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Vehicles;

public record DeleteBrandRequest(int Id) : IRequest<bool>;