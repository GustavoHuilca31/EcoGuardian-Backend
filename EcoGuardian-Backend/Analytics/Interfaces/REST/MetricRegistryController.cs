using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;
using EcoGuardian_Backend.Analytics.Domain.Services;
using EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;
using EcoGuardian_Backend.Analytics.Interfaces.REST.Transform;
using EcoGuardian_Backend.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using EcoGuardian_Backend.Shared.Interfaces.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.Analytics.Interfaces.REST;

[Route("api/v1/[controller]")]
[ApiController]
[ProducesResponseType(500)]
public class MetricRegistryController(IMetricRegistryCommandService metricRegistryCommandService, IMetricRegistryQueryService metricRegistryQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AllowAnonymous]
    public async Task<IActionResult> CreateMetricRegistry([FromBody] CreateMetricRegistryResource resource)
    {
        var command = CreateMetricRegistryCommandFromResourceAssembler.ToCommandFromResource(resource);
        await metricRegistryCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, true);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetMetricRegistriesByDeviceId([FromQuery] int deviceId, [FromQuery] string? period = null)
    {
        if (string.IsNullOrEmpty(period))
        {
            var query = new GetMetricsRegistriesByDeviceIdQuery(deviceId);
            var registries = await metricRegistryQueryService.Handle(query);
            var resources = registries.Select(MetricRegistryResourceFromEntityAssembler.ToResourceFromEntity).ToList();
            return Ok(resources);
        }
        var periodQuery = new GetMetricRegistriesByPeriodQuery(deviceId, period);
        var aggregated = await metricRegistryQueryService.Handle(periodQuery);
        var aggregatedResources = aggregated.Select(MetricRegistryResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(aggregatedResources);
    }

    [HttpGet("devices/{deviceId}/latest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetLatestMetricRegistryByDeviceId([FromRoute] int deviceId)
    {
        var query = new GetLatestMetricRegistryByDeviceIdQuery(deviceId);
        var registry = await metricRegistryQueryService.Handle(query);
        if (registry == null) return NotFound();
        var resource = MetricRegistryResourceFromEntityAssembler.ToResourceFromEntity(registry);
        return Ok(resource);
    }
}
