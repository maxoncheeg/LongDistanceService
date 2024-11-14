using LongDistanceService.Data.Entities.Abstract;
using LongDistanceService.Data.Entities.Personals;

namespace LongDistanceService.Data.Entities.Addresses;

public class Street : AbstractNameEntity
{
    public IList<Order> ReceiveOrders { get; set; } = new List<Order>();
    public IList<Order> SendOrders { get; set; } = new List<Order>();
    public IList<Legal> Legals { get; set; } = new List<Legal>();
}