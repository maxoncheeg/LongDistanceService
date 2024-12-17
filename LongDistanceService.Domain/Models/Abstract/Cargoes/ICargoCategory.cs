namespace LongDistanceService.Domain.Models.Abstract.Cargoes;

public interface ICargoCategory
{
    public int Id { get; set; }
    public IUnit Unit { get; set; }
    public string Name { get; set; }
}