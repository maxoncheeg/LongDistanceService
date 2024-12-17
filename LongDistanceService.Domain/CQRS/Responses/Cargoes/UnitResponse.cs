using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.CQRS.Responses.Cargoes;

public class UnitResponse : IUnit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}