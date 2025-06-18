using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Model.Queries;
using EcoGuardian_Backend.Planning.Domain.Services;
using EcoGuardian_Backend.Planning.Interfaces.REST.Resources;
using EcoGuardian_Backend.Planning.Interfaces.REST.Transform;
using EcoGuardian_Backend.Shared.Interfaces.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.Planning.Interfaces.REST;

[Route("api/v1/[controller]")]
[ApiController]
[ProducesResponseType(500)]

public class OrderController(IOrderCommandService orderCommandService, IOrderQueryService orderQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var command = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        await orderCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, true);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderResource resource)
    {
        var command = UpdateOrderCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        await orderCommandService.Handle(command);
        return Ok(true);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetOrdersByConsumerId([FromQuery] int consumerId)
    {
        var query = new GetOrdersByConsumerIdQuery(consumerId);
        var orders = await orderQueryService.Handle(query);
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
}
