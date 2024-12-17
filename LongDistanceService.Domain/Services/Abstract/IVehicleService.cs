using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Vehicles;
using LongDistanceService.Domain.Models.Options;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IVehicleService
{
    public Task<IList<IVehicleInfo>> GetVehiclesAsync(int take = 30, int skip = 0, VehicleSearchOptions? options = null);
    public Task<IList<IModel>> GetModelsAsync();
    public Task<IVehicle?> GetVehicleAsync(int id);
    public Task AddOrUpdateVehicleAsync(IEditVehicle vehicle);
    public Task DeleteVehicleAsync(int id);
}