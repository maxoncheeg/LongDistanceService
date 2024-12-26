using LongDistanceService.Domain.Models.Abstract.Drivers;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Drivers;

public record EditDriverCategoryRequest() : IRequest<bool>, IDriverCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}