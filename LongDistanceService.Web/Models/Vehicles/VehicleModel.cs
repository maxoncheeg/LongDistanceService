using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Web.Models.Vehicles;

public class VehicleModel : IEditVehicle
{
    public int Id { get; set; }
    [Required]
    public int ModelId { get; set; }
    [Required, Range(1900, 2025)]
    public int Year { get; set; }
    
    [Required, Range(1900, 2025)]
    public int OverhaulYear { get; set; }
    
    [Required, RegularExpression(@"(?i)^[АВЕКМНОРСТУХABEKMHOPCTYX]\d{3}[АВЕКМНОРСТУХABEKMHOPCTYX]{2}\d{2,3}$", ErrorMessage = "Пример знака: M666AX154")]
    public string LicensePlate { get; set; }
    [Required, Range(0, 5000000)]
    public decimal Kilometerage { get; set; }
    public string? ImagePath { get; set; }
    public int[] CargoCategoryIds { get; set; } = [];
}