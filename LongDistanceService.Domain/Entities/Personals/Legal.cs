using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Addresses;

namespace LongDistanceService.Domain.Entities.Personals;

public class Legal : AbstractPersonalEntity
{
    public int CityId { get; set; }
    public int StreetId { get; set; }
    public int BankId { get; set; }
    
    public City City { get; set; } = new();
    public Street Street { get; set; } = new();
    public Bank Bank { get; set; } = new();
    
    public string CompanyName { get; set; }  = String.Empty;
    public string Phone { get; set; }  = String.Empty;
    public string TIN { get; set; }  = String.Empty;
    public string BankAccount { get; set; }  = String.Empty;
    public int HouseNumber { get; set; }
    public int OfficeNumber { get; set; }
}