using LongDistanceService.Domain.Models.Abstract.Drivers;
using LongDistanceService.Domain.Models.Options;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IDriverService
{
    public Task<IList<IDriverInfo>> GetDriversAsync(int take = 30, int skip = 0, DriverSearchOptions? options = null);
    public Task<IDriver?> GetDriverAsync(int id);
    public Task<bool> DeleteDriverAsync(int id);
    public Task<bool> AddOrUpdateDriverAsync(IEditDriver driver);
    public Task<IList<IDriverCategory>> GetDriverCategoriesAsync();
    public Task<bool> AddOrUpdateDriverCategoryAsync(IDriverCategory driverCategory);
    public Task<bool> DeleteDriverCategoryAsync(int id);
}