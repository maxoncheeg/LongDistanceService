using LongDistanceService.Domain.Models.Abstract.Order;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IOrderService
{
    public Task<IList<IOrderInfo>> GetOrdersInfo();
    public Task<IOrder?> GetOrderById(int orderId);
    public Task<bool> AddOrder(IOrderOnAdd orderInfo);
}