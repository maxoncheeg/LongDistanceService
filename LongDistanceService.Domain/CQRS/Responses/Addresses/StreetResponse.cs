using LongDistanceService.Domain.Models.Abstract.Addresses;

namespace LongDistanceService.Domain.CQRS.Responses.Addresses;

public class StreetResponse : IStreet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}