using LongDistanceService.Domain.CQRS.Responses.Personals;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.Personals;

public class GetBanksRequest : IRequest<IList<BankResponse>>
{
    
}