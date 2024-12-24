using LongDistanceService.Domain.Models.Abstract.Drivers;

namespace LongDistanceService.Domain.CQRS.Responses.Drivers;

public class DriverCategoryResponse : IDriverCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}