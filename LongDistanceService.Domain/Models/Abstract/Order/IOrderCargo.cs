using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface IOrderCargo
{
    public int Id { get; set; }
    public ICargo Cargo { get; set; }
    public IOrder Order { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}