using EcoGuardian_Backend.Resources.Domain.Model.Queries;
using EcoGuardian_Backend.Resources.Domain.Services;
using EcoGuardian_Backend.Resources.Interfaces.REST.Resources;
using EcoGuardian_Backend.Resources.Interfaces.REST.Transform;
using EcoGuardian_Backend.Shared.Interfaces.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.Resources.Interfaces.REST;

[Route("api/v1/devices")]
[ApiController]
[ProducesResponseType(500)]
public class DeviceController(IDeviceCommandService deviceCommandService, IDeviceQueryService deviceQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceResource resource)
    {
        var command = CreateDeviceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var device = await deviceCommandService.Handle(command);
        
        return StatusCode(201, new
        {
            message = "Device created successfully",
            id = device.Id
        });
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    public async Task<IActionResult> UpdateDevice([FromBody] UpdateDeviceResource resource, [FromRoute] int id)
    {
        var command = UpdateDeviceCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        await deviceCommandService.Handle(command);
        return Ok(true);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetDevicesByPlantId([FromQuery] int plantId)
    {
        var query = new GetDevicesByPlantIdQuery(plantId);
        var devices = await deviceQueryService.Handle(query);
        var resources = devices.Select(DeviceResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
    
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetAllDevices()
    {
        var query = new GetAllDevicesQuery();
        var devices = await deviceQueryService.Handle(query);
        var resources = devices.Select(DeviceResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
}
