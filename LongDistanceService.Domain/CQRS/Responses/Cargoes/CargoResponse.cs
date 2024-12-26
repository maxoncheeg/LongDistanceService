using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.CQRS.Responses.Cargoes;

public class CargoResponse : ICargo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICargoCategory Category { get; set; } = null!;
}