using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Data.Entities.Identity;

namespace LongDistanceService.Data.Entities.Personals;

public class Individual : AbstractPersonalEntity
{
    public string Phone { get; set; } = String.Empty;
    public string PassportSeries { get; set; } = String.Empty;
    public DateOnly PassportDate { get; set; }
    public string PassportIssued { get; set; } = String.Empty;

    public IList<Order> ReceivedOrders { get; set; }
    public IList<Order> SendedOrders { get; set; }
    public User? User { get; set; }
}