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

[Route("api/v1/metrics")]
[ApiController]
[ProducesResponseType(500)]
public class MetricController(IMetricCommandService metricCommandService, IMetricQueryService metricQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AllowAnonymous]
    public async Task<IActionResult> CreateMetric([FromBody] CreateMetricResource resource)
    {
        var command = CreateMetricCommandFromResourceAssembler.ToCommandFromResource(resource);
        await metricCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, true);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetMetricsByDeviceId([FromQuery] int deviceId)
    {
        var query = new GetMetricsByDeviceIdQuery(deviceId);
        var metrics = await metricQueryService.Handle(query);
        var resources = metrics.Select(MetricResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("by-device-and-type")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetMetricsByDeviceIdAndMetricTypeId([FromQuery] int deviceId, [FromQuery] int metricTypeId)
    {
        var query = new GetMetricsByDeviceIdAndMetricTypeIdQuery(deviceId, metricTypeId);
        var metrics = await metricQueryService.Handle(query);
        var resources = metrics.Select(MetricResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("latest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetLatestMetricByDeviceId([FromQuery] int deviceId)
    {
        var metric = await metricQueryService.GetLatestMetricByDeviceIdAsync(deviceId);
        if (metric == null) return NotFound();
        var resource = MetricResourceFromEntityAssembler.ToResourceFromEntity(metric);
        return Ok(resource);
    }

    [HttpGet("latest/by-device-and-type")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetLatestMetricByDeviceIdAndMetricTypeId([FromQuery] int deviceId, [FromQuery] int metricTypeId)
    {
        var metric = await metricQueryService.GetLatestMetricByDeviceIdAndMetricTypeIdAsync(deviceId, metricTypeId);
        if (metric == null) return NotFound();
        var resource = MetricResourceFromEntityAssembler.ToResourceFromEntity(metric);
        return Ok(resource);
    }

    [HttpGet("last-n/by-device-and-type")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [AuthorizeFilter("Admin", "Domestic", "Business", "Specialist")]
    public async Task<IActionResult> GetLastNMetricsByDeviceIdAndMetricTypeId([FromQuery] int deviceId, [FromQuery] int metricTypeId, [FromQuery] int n)
    {
        var metrics = await metricQueryService.GetLastNMetricsByDeviceIdAndMetricTypeIdAsync(deviceId, metricTypeId, n);
        var resources = metrics.Select(MetricResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
}
