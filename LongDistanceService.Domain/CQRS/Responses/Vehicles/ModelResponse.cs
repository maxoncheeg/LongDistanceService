using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.CQRS.Responses.Vehicles;

public class ModelResponse : IModel
{
    public int Id { get; set; }
    public IBrand Brand { get; set; } = null!;
    public string Name { get; set; } = string.Empty;
}