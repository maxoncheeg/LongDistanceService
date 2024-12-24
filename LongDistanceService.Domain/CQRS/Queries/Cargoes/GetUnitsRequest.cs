using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Cargoes;

public class GetUnitsRequest : IRequest<IList<UnitResponse>>
{
    
}