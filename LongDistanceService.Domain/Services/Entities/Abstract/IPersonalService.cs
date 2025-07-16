using LongDistanceService.Domain.Models.Abstract.Personals;
using LongDistanceService.Domain.Models.Options;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IPersonalService
{
    public Task<IList<ILegal>> GetLegalsAsync(int take = 50, int skip = 0, LegalSearchOptions? searchOptions = null);
    public Task<bool> AddOrUpdateLegalAsync(IEditLegal legal);
    public Task<bool> DeleteLegalAsync(int id);
    public Task<IList<IIndividual>> GetIndividualsAsync(int take = 50, int skip = 0, IndividualSearchOptions? searchOptions = null);
    public Task<bool> AddOrUpdateIndividualAsync(IIndividual individual);
    public Task<bool> DeleteIndividualAsync(int id);
}