using LongDistanceService.Data.Entities.Personals;
using LongDistanceService.Domain.CQRS.Responses.Personals;

namespace LongDistanceService.Data.Mappings;

public static class PersonalsMappingExtensions
{
    public static IQueryable<IndividualInfoResponse> ToIndividualInfoResponse(this IQueryable<Individual> @this)
    {
        return @this.Select(i => new IndividualInfoResponse()
        {
            Id = i.Id,
            Fullname = $"{i.Surname} {i.Name} {i.Patronymic}"
        });
    }
    
    public static IQueryable<LegalInfoResponse> ToLegalInfoResponse(this IQueryable<Legal> @this)
    {
        return @this.Select(l => new LegalInfoResponse()
        {
            Id = l.Id,
            CompanyName = l.CompanyName
        });
    }
    
    public static LegalInfoResponse? ToLegalInfoResponse(this Legal? @this)
    {
        if (@this == null) return null;
        
        return new LegalInfoResponse
        {
            Id = @this.Id,
            CompanyName = @this.CompanyName
        };
    }
    
    public static IndividualInfoResponse? ToIndividualInfoResponse(this Individual? @this)
    {
        if (@this == null) return null;
        
        return new IndividualInfoResponse
        {
            Id = @this.Id,
            Fullname = $"{@this.Surname} {@this.Name} {@this.Patronymic}"
        };
    }
}