using LongDistanceService.Domain.Models.Abstract.Addresses;

namespace LongDistanceService.Domain.CQRS.Responses.Addresses;

public class CityResponse : ICity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}