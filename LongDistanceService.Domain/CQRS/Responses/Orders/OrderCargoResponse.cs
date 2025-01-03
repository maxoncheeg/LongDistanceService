using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Order;

namespace LongDistanceService.Domain.CQRS.Responses.Orders;

public class OrderCargoResponse : IOrderCargo
{
    public int Id { get; set; }
    public ICargo Cargo { get; set; } = new CargoResponse();
    public IOrder Order { get; set; } = new OrderResponse();
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}