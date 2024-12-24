using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Personals;
using LongDistanceService.Domain.CQRS.Responses.Personals;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Personals;

public class GetBanksHandler(IApplicationDbContext context) : IRequestHandler<GetBanksRequest, IList<BankResponse>>
{
    public async Task<IList<BankResponse>> Handle(GetBanksRequest request, CancellationToken cancellationToken)
    {
        var banks = await context.Banks.Select(b => new BankResponse() { Id = b.Id, Name = b.Name })
            .ToListAsync(cancellationToken: cancellationToken);
        return banks;
    }
}