using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Cargoes;

public record GetCargoCategoriesRequest() : IRequest<IList<CargoCategoryResponse>>;