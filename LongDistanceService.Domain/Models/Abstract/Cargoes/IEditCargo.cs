namespace LongDistanceService.Domain.Models.Abstract.Cargoes;

public interface IEditCargo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
}