namespace LongDistanceService.Domain.Models.Abstract.Cargoes;

public interface ICargo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICargoCategory Category { get; set; }
}