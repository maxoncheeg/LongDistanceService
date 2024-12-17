using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.Services.Abstract;

public interface ICargoService
{
    public Task<IList<ICargoCategory>> GetCargoCategoriesAsync();
}