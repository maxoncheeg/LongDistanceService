using LongDistanceService.Domain.Models.Abstract.Vehicles;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Vehicles;

public class EditVehicleRequest : IRequest, IEditVehicle
{
    public int Id { get; set; } = 0;
    public int ModelId { get; set; }
    public int Year { get; set; }
    public int OverhaulYear { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public decimal Kilometerage { get; set; }
    public string? ImagePath { get; set; }
    public int[] CargoCategoryIds { get; set; } = [];
}