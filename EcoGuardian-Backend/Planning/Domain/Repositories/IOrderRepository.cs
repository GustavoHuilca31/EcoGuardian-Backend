using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Planning.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByConsumerIdAsync(int consumerId);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
}