using LongDistanceService.Domain.CQRS.Responses.Drivers;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Drivers;

public record GetDriverRequest(int Id) : IRequest<DriverResponse?>;