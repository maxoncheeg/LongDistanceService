using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Vehicles;

public record GetModelsRequest : IRequest<IList<ModelResponse>>;