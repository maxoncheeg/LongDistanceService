using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.Services.Abstract;

public interface ICargoService
{
    public Task<IList<ICargoCategory>> GetCargoCategoriesAsync();
    public Task<bool> AddOrUpdateCargoCategoryAsync(IEditCargoCategory category);
    public Task<bool> DeleteCargoCategoryAsync(int id);
    public Task<IList<IUnit>> GetUnitsAsync();
    public Task<bool> AddOrUpdateUnitAsync(IUnit unit);
    public Task<bool> DeleteUnitAsync(int id);
    public Task<IList<ICargo>> GetCargoesAsync();
    public Task<bool> AddOrUpdateCargoAsync(IEditCargo cargo);
    public Task<bool> DeleteCargoAsync(int id);
}