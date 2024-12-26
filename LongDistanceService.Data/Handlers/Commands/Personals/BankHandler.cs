using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Personals;
using LongDistanceService.Domain.CQRS.Commands.Personals;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Personals;

public class BankHandler(IApplicationDbContext context)
    : IRequestHandler<EditBankRequest, bool>, IRequestHandler<DeleteBankRequest, bool>
{
    public async Task<bool> Handle(EditBankRequest request, CancellationToken cancellationToken)
    {
        var bank = request.Id != 0
            ? await context.Banks.SingleOrDefaultAsync(b => b.Id == request.Id, cancellationToken: cancellationToken)
            : new Bank();

        if (bank == null) return false;
        try
        {
            bank.Name = request.Name;
            context.Update(bank);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteBankRequest request, CancellationToken cancellationToken)
    {
        var bank = await context.Banks.SingleOrDefaultAsync(b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        if (bank == null) return false;
        
        try
        {
            context.Delete(bank);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }
}