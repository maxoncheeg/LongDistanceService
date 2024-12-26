using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Personals;
using LongDistanceService.Domain.CQRS.Commands.Personals;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Personals;

public class PersonalHandler(IApplicationDbContext context) : IRequestHandler<EditIndividualRequest, bool>,
    IRequestHandler<DeleteIndividualRequest, bool>
    , IRequestHandler<EditLegalRequest, bool>, IRequestHandler<DeleteLegalRequest, bool>
{
    public async Task<bool> Handle(EditIndividualRequest request, CancellationToken cancellationToken)
    {
        var individual = request.Id != 0
            ? await context.Individuals.SingleOrDefaultAsync(b => b.Id == request.Id,
                cancellationToken: cancellationToken)
            : new Individual();

        if (individual == null) return false;
        try
        {
            individual.Id = request.Id;
            individual.Name = request.Name;
            individual.Surname = request.Surname;
            individual.Patronymic = request.Patronymic;
            individual.Phone = request.Phone;
            individual.PassportDate = request.PassportDate;
            individual.PassportSeries = request.PassportSeries;
            individual.PassportIssued = request.PassportIssued;
            
            context.Update(individual);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteIndividualRequest request, CancellationToken cancellationToken)
    {
        var individual = await context.Individuals.SingleOrDefaultAsync(b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        if (individual == null) return false;
        try
        {
            context.Delete(individual);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(EditLegalRequest request, CancellationToken cancellationToken)
    {
        if (request.BankId == 0 || request.CityId == 0 || request.StreetId == 0) return false;

        var legal = request.Id != 0
            ? await context.Legals.SingleOrDefaultAsync(b => b.Id == request.Id,
                cancellationToken: cancellationToken)
            : new Legal();
        var bank = await context.Banks.SingleOrDefaultAsync(b => b.Id == request.BankId,
            cancellationToken: cancellationToken);
        var city = await context.Cities.SingleOrDefaultAsync(b => b.Id == request.CityId,
            cancellationToken: cancellationToken);
        var street = await context.Streets.SingleOrDefaultAsync(b => b.Id == request.StreetId,
            cancellationToken: cancellationToken);

        if (bank == null || city == null || street == null || legal == null) return false;
        try
        {
            legal.Id = request.Id;
            legal.Name = request.Name;
            legal.Surname = request.Surname;
            legal.Patronymic = request.Patronymic;
            legal.Phone = request.Phone;
            legal.BankAccount = request.Account;
            legal.TIN = request.TIN;
            legal.HouseNumber = request.HouseNumber;
            legal.OfficeNumber = request.OfficeNumber;
            legal.CompanyName = request.CompanyName;
            legal.Bank = bank;
            legal.City = city;
            legal.Street = street;
            
            context.Update(legal);
            await context.SaveAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(DeleteLegalRequest request, CancellationToken cancellationToken)
    {
        var legal = await context.Legals.SingleOrDefaultAsync(b => b.Id == request.Id,
            cancellationToken: cancellationToken);

        if (legal == null) return false;
        try
        {
            context.Delete(legal);
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