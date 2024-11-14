using LongDistanceService.Data.Entities.Abstract;

namespace LongDistanceService.Data.Entities.Cargoes;

public class Unit : AbstractNameEntity
{
    public IList<CargoCategory> CargoCategories { get; set; }= new List<CargoCategory>();
}