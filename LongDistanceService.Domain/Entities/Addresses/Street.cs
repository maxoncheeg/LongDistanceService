using LongDistanceService.Domain.Entities.Abstract;
using LongDistanceService.Domain.Entities.Personals;

namespace LongDistanceService.Domain.Entities.Addresses;

public class Street : AbstractNameEntity
{
    public IList<Order> ReceiveOrders { get; set; } = new List<Order>();
    public IList<Order> SendOrders { get; set; } = new List<Order>();
    public IList<Legal> Legals { get; set; } = new List<Legal>();
}