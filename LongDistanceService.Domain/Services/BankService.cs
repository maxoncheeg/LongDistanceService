using LongDistanceService.Domain.CQRS.Commands.Personals;
using LongDistanceService.Domain.CQRS.Queries.Personals;
using LongDistanceService.Domain.Models.Abstract.Personals;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class BankService(IMediator mediator) : IBankService
{
    public async Task<IList<IBank>> GetBanksAsync()
    {
        return [..await mediator.Send(new GetBanksRequest())];
    }

    public async Task<bool> AddOrUpdateBankAsync(IBank bank)
    {
        return await mediator.Send(new EditBankRequest() { Id = bank.Id, Name = bank.Name });
    }

    public async Task<bool> DeleteBankAsync(int id)
    {
        return await mediator.Send(new DeleteBankRequest() { Id = id });
    }
}