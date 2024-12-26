using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Web.Models.Cargoes;

public class CargoCategoryModel : IEditCargoCategory
{
    public int Id { get; set; }

    [Required, MaxLength(32, ErrorMessage = "Максимум 32 символа"), MinLength(1, ErrorMessage = "Не может быть пустым")]
    public string Name { get; set; } = string.Empty;

    public int UnitId { get; set; }
}