using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Personals;
using LongDistanceService.Domain.CQRS.Responses.Addresses;
using LongDistanceService.Domain.CQRS.Responses.Personals;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Personals;

public class GetPersonalsHandler(IApplicationDbContext context)
    : IRequestHandler<GetIndividualsRequest, IList<IndividualResponse>>,
        IRequestHandler<GetLegalsRequest, IList<LegalResponse>>
{
    public async Task<IList<IndividualResponse>> Handle(GetIndividualsRequest request,
        CancellationToken cancellationToken)
    {
        var individuals = await context.Individuals.Select(l => new IndividualResponse()
            {
                Id = l.Id,
                Name = l.Name,
                Surname = l.Surname,
                Patronymic = l.Patronymic,
                PassportDate = l.PassportDate,
                PassportIssued = l.PassportIssued,
                PassportSeries = l.PassportSeries,
                Phone = l.Phone
            })
            .Skip(request.Skip)
            .Take(request.Take)
            .ToListAsync(cancellationToken);

        return individuals;
    }

    public async Task<IList<LegalResponse>> Handle(GetLegalsRequest request, CancellationToken cancellationToken)
    {
        var legals = await context.Legals.Select(l => new LegalResponse()
            {
                Id = l.Id,
                Name = l.Name,
                Surname = l.Surname,
                Patronymic = l.Patronymic,
                Phone = l.Phone,
                Account = l.BankAccount,
                TIN = l.TIN,
                HouseNumber = l.HouseNumber,
                OfficeNumber = l.OfficeNumber,
                CompanyName = l.CompanyName,
                Bank = new BankResponse()
                {
                    Id = l.BankId,
                    Name = l.Bank.Name
                },
                City = new CityResponse()
                {
                    Id = l.CityId,
                    Name = l.City.Name
                },
                Street = new StreetResponse()
                {
                    Id = l.StreetId,
                    Name = l.Street.Name
                }
            })
            .Skip(request.Skip)
            .Take(request.Take)
            .ToListAsync(cancellationToken);

        return legals;
    }
}