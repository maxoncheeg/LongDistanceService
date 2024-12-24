using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Web.Models.Personals;

public class BankModel : IBank
{
    public int Id { get; set; }
    [Required, MaxLength(32, ErrorMessage = "Максимум 32 символа"), MinLength(1, ErrorMessage = "Не может быть пустым")]
    public string Name { get; set; } = string.Empty;
}