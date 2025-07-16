using LongDistanceService.Domain.Models.Abstract.Vehicles;
using LongDistanceService.Domain.Models.Options;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IVehicleService
{
    public Task<IList<IVehicleInfo>> GetVehiclesAsync(int take = 30, int skip = 0, VehicleSearchOptions? options = null);
    public Task<IList<IModel>> GetModelsAsync();
    public Task<IVehicle?> GetVehicleAsync(int id);
    public Task AddOrUpdateVehicleAsync(IEditVehicle vehicle);
    public Task DeleteVehicleAsync(int id);
    public Task<IList<IBrand>> GetBrandsAsync();
    public Task<bool> AddOrUpdateBrandAsync(IBrand brand);
    public Task<bool> DeleteBrandAsync(int id);
    public Task<bool> AddOrUpdateModelAsync(IEditModel model);
    public Task<bool> DeleteModelAsync(int id);
}