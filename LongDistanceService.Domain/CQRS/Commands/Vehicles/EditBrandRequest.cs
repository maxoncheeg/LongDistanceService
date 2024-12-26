using LongDistanceService.Domain.Models.Abstract.Vehicles;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Vehicles;

public record EditBrandRequest : IRequest<bool>, IBrand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}