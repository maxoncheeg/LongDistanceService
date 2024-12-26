using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Web.Models.Vehicles;

public class VehicleBrandModel : IBrand
{
    public int Id { get; set; }
    [Required, MaxLength(32, ErrorMessage = "Максимум 32 символа"), MinLength(1, ErrorMessage = "Не может быть пустым")]
    public string Name { get; set; } = string.Empty;
}