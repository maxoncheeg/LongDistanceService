using LongDistanceService.Domain.Entities.Abstract;

namespace LongDistanceService.Domain.Entities.Cargoes;

public class Unit : AbstractNameEntity
{
    public IList<CargoCategory> CargoCategories { get; set; }= new List<CargoCategory>();
}