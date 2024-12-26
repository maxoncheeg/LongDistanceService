namespace LongDistanceService.Domain.Models.Abstract.Cargoes;

public interface IEditCargoCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UnitId { get; set; }
}