using LongDistanceService.Data.Entities.Personals;
using LongDistanceService.Domain.CQRS.Responses.Personals;

namespace LongDistanceService.Data.Mappings;

public static class PersonalsMappingExtensions
{
    public static IQueryable<SlimIndividualResponse> ToSlimIndividualResponse(this IQueryable<Individual> @this)
    {
        return @this.Select(i => new SlimIndividualResponse()
        {
            Id = i.Id,
            Fullname = $"{i.Surname} {i.Name} {i.Patronymic}"
        });
    }
    
    public static IQueryable<SlimLegalResponse> ToSlimLegalResponse(this IQueryable<Legal> @this)
    {
        return @this.Select(l => new SlimLegalResponse()
        {
            Id = l.Id,
            CompanyName = l.CompanyName
        });
    }
    
    public static SlimLegalResponse? ToSlimLegalResponse(this Legal? @this)
    {
        if (@this == null) return null;
        
        return new SlimLegalResponse
        {
            Id = @this.Id,
            CompanyName = @this.CompanyName
        };
    }
    
    public static SlimIndividualResponse? ToSlimIndividualResponse(this Individual? @this)
    {
        if (@this == null) return null;
        
        return new SlimIndividualResponse
        {
            Id = @this.Id,
            Fullname = $"{@this.Surname} {@this.Name} {@this.Patronymic}"
        };
    }
}