using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Addresses;

namespace LongDistanceService.Domain.Entities.Personals;

public class Legal : AbstractPersonalEntity
{
    public int CityId { get; set; }
    public int StreetId { get; set; }
    public int BankId { get; set; }
    
    public City City { get; set; }
    public Street Street { get; set; }
    public Bank Bank { get; set; }
    
    public string CompanyName { get; set; }
    public string Phone { get; set; }
    public string TIN { get; set; }
    public string Account { get; set; }
    public int HouseNumber { get; set; }
    public int OfficeNumber { get; set; }
}