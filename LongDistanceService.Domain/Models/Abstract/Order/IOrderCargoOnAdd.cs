using LongDistanceService.Domain.Models.Abstract.Cargoes;

namespace LongDistanceService.Domain.Models.Abstract.Order;

public interface IOrderCargoOnAdd
{
    public int Id { get; set; }
    public int CargoId { get; set; }
    public decimal Amount { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}