using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.CQRS.Responses.Vehicles;

public class BrandResponse : IBrand
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
}