using LongDistanceService.Domain.Models.Abstract.Addresses;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IAddressService
{
    public Task<IList<ICity>> GetCitiesAsync();
    public Task<bool> AddOrUpdateCityAsync(ICity city);
    public Task<bool> DeleteCityAsync(int id);
    public Task<IList<IStreet>> GetStreetsAsync();
    public Task<bool> AddOrUpdateStreetAsync(IStreet street);
    public Task<bool> DeleteStreetAsync(int id);
}