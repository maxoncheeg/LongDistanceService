using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.CQRS.Responses.Cargoes;

public class CargoCategoryResponse : ICargoCategory
{
    public int Id { get; set; }
    public IUnit Unit { get; set; } = null!;
    public string Name { get; set; } = String.Empty;
}