using LongDistanceService.Domain.Models.Abstract.Order;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IOrderService
{
    public Task<IList<ISlimOrder>> GetSlimOrders(int userId, int skip, int take);
    public Task<IOrder?> GetOrderById(int orderId);
    public Task<bool> AddOrder(IOrderOnAdd orderInfo);
}