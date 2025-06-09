﻿using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Repositories;
using EcoGuardian_Backend.Planning.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Planning.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IOrderCommandService
{
    public async Task Handle(CreateOrderCommand command)
    {
        var order = new Order(command);
        await orderRepository.AddAsync(order);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(UpdateOrderCommand command)
    {
        var order = await orderRepository.GetByIdAsync(command.Id);
        if (order == null)
        {
            throw new KeyNotFoundException($"Order with ID {command.Id} not found.");
        }

        order.Update(command);
        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(CompletePaymentOrderCommand command)
    {
        var order = await orderRepository.GetByIdAsync(command.OrderId);
        if (order == null)
            throw new KeyNotFoundException($"Order with ID {command.OrderId} not found.");
        order.CompletePayment();
        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(CompleteInstallationOrderCommand command)
    {
        var order = await orderRepository.GetByIdAsync(command.OrderId);
        if (order == null)
            throw new KeyNotFoundException($"Order with ID {command.OrderId} not found.");
        order.CompleteInstallation();
        orderRepository.Update(order);
        await unitOfWork.CompleteAsync();
    }
}