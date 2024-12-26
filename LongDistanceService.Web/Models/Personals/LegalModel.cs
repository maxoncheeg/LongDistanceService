using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract.Personals;

namespace LongDistanceService.Web.Models.Personals;

public class LegalModel : IEditLegal
{
    public int Id { get; set; }
    public int BankId { get; set; }
    public int CityId { get; set; }
    public int StreetId { get; set; }
    [Required, MaxLength(32, ErrorMessage = "Максимальная длина 32")]
    public string Name { get; set; }
    [Required, MaxLength(32, ErrorMessage = "Максимальная длина 32")]
    public string Surname { get; set; }
    [Required, MaxLength(32, ErrorMessage = "Максимальная длина 32")]
    public string Patronymic { get; set; }
    [Required, RegularExpression(@"^8\d{10}$", ErrorMessage = "Пример: 89831335714")]
    public string Phone { get; set; }
    [Required, MaxLength(32, ErrorMessage = "Максимальная длина 32")]
    public string CompanyName { get; set; }
    [Required, MaxLength(10, ErrorMessage = "Максимальная длина 10"), RegularExpression(@"^\d*$", ErrorMessage = "Только цифры")]
    public string TIN { get; set; }
    [Required, MaxLength(6, ErrorMessage = "Максимальная длина 6"), MinLength(6, ErrorMessage = "Минимальная длина 6"), RegularExpression(@"\d*", ErrorMessage = "Только цифры")]
    public string Account { get; set; }
    [Required, MaxLength(16, ErrorMessage = "Максимальная длина 16")]
    public string HouseNumber { get; set; }
    [Required, MaxLength(16, ErrorMessage = "Максимальная длина 16")]
    public string OfficeNumber { get; set; }
}