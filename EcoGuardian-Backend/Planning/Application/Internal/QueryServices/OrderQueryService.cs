using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Planning.Domain.Model.Queries;
using EcoGuardian_Backend.Planning.Domain.Repositories;
using EcoGuardian_Backend.Planning.Domain.Services;

namespace EcoGuardian_Backend.Planning.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository repository) : IOrderQueryService
{
    public Task<IEnumerable<Order>> Handle(GetOrdersByConsumerIdQuery query)
    {
        return repository.GetOrdersByConsumerIdAsync(query.ConsumerId);
    }

    public Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return repository.GetAllOrdersAsync();
    }
}