using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Planning.Domain.Model.Commands;

namespace EcoGuardian_Backend.Planning.Domain.Services;

public interface IOrderCommandService
{
    Task<Order> Handle(CreateOrderCommand command);
    Task Handle(UpdateOrderCommand command);
    Task Handle(UpdateOrderStateCommand command);

}