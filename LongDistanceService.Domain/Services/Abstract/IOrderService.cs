using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Order;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IOrderService
{
    public Task<IList<IOrderInfo>> GetOrdersInfo();
    public Task<IOrder?> GetOrderById(int orderId);
}