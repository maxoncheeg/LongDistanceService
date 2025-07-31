using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Data.Entities.Addresses;
using LongDistanceService.Data.Entities.Identity;

namespace LongDistanceService.Data.Entities.Personals;

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
    public string HouseNumber { get; set; }
    public string OfficeNumber { get; set; }
    public IList<Order> ReceivedOrders { get; set; }
    public IList<Order> SendedOrders { get; set; }
}