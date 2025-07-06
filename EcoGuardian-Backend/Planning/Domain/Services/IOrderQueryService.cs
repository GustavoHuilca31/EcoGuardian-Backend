using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Planning.Domain.Model.Queries;

namespace EcoGuardian_Backend.Planning.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetOrdersByConsumerIdQuery query);
    // get all
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
}