using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Drivers;

namespace LongDistanceService.Web.Models.Drivers;

public class DriverCategoryModel : IDriverCategory
{
    public int Id { get; set; }
    [Required, MaxLength(4, ErrorMessage = "Максимум 4 символа"), MinLength(1, ErrorMessage = "Не может быть пустым")]
    public string Name { get; set; } = string.Empty;
}