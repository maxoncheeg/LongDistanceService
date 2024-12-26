using LongDistanceService.Domain.CQRS.Responses.Cargoes;

namespace LongDistanceService.Domain.CQRS.Queries.Cargoes;

public record GetCargoesRequest : ScrolledRequest<CargoResponse>;