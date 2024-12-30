using LongDistanceService.Domain.Models.Abstract.Order;

namespace LongDistanceService.Web.Models.Orders;

public class OrderCargoModel : IOrderCargoOnAdd
{
    public int Id { get; set; }
    public int CargoId { get; set; }
    public decimal Amount { get; set; } = 20;
    public decimal Price { get; set; } = 1000;
    public decimal Weight { get; set; } = 100;
}