using LongDistanceService.Domain.Models.Abstract.Vehicles;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Vehicles;

public record EditModelRequest : IRequest<bool>, IEditModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int BrandId { get; set; }
}