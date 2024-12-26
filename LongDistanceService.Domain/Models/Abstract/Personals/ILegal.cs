using LongDistanceService.Domain.Models.Abstract.Addresses;

namespace LongDistanceService.Domain.Models.Abstract.Personals;

public interface ILegal
{
    public int Id { get; set; }
    public IBank Bank { get; set; }
    public ICity City { get; set; } 
    public IStreet Street { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public string Phone { get; set; }
    public string CompanyName { get; set; }
    public string TIN { get; set; }
    public string Account { get; set; }
    public string HouseNumber { get; set; }
    public string OfficeNumber { get; set; }
    
}