using LongDistanceService.Domain.CQRS.Commands.Personals;
using LongDistanceService.Domain.CQRS.Queries.Personals;
using LongDistanceService.Domain.Models.Abstract.Personals;
using LongDistanceService.Domain.Models.Options;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class PersonalService(IMediator mediator) : IPersonalService
{
    public async Task<IList<ILegal>> GetLegalsAsync(int take = 50, int skip = 0, LegalSearchOptions? searchOptions = null)
    {
        return [..await mediator.Send(new GetLegalsRequest() { Skip = skip, Take = take, Options = searchOptions })];
    }

    public async Task<bool> AddOrUpdateLegalAsync(IEditLegal legal)
    {
        return await mediator.Send(new EditLegalRequest()
        {
            Id = legal.Id,
            Name = legal.Name,
            Surname = legal.Surname,
            Phone = legal.Phone,
            Patronymic = legal.Patronymic,
            Account = legal.Account,
            HouseNumber = legal.HouseNumber,
            OfficeNumber = legal.OfficeNumber,
            BankId = legal.BankId,
            CityId = legal.CityId,
            StreetId = legal.StreetId,
            TIN = legal.TIN,
            CompanyName = legal.CompanyName
        });
    }

    public async Task<bool> DeleteLegalAsync(int id)
    {
        return await mediator.Send(new DeleteLegalRequest(id));
    }

    public async Task<IList<IIndividual>> GetIndividualsAsync(int take = 50, int skip = 0, IndividualSearchOptions? searchOptions = null)
    {
        return [..await mediator.Send(new GetIndividualsRequest() { Skip = skip, Take = take, Options = searchOptions })];
    }

    public async Task<bool> AddOrUpdateIndividualAsync(IIndividual individual)
    {
        return await mediator.Send(new EditIndividualRequest()
        {
            Id = individual.Id,
            Name = individual.Name,
            Surname = individual.Surname,
            Phone = individual.Phone,
            Patronymic = individual.Patronymic,
            PassportDate = individual.PassportDate,
            PassportIssued = individual.PassportIssued,
            PassportSeries = individual.PassportSeries
        });
    }

    public async Task<bool> DeleteIndividualAsync(int id)
    {
        return await mediator.Send(new DeleteIndividualRequest(id));
    }
}