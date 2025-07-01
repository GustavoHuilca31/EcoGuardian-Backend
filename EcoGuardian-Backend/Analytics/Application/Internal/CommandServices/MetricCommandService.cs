using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;
using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Analytics.Application.Internal.CommandServices;

public class MetricCommandService(IHttpContextAccessor currentSession, IMetricRepository metricRepository, IExternalNotificationService notificationService, IUnitOfWork unitOfWork) : IMetricCommandService
{
    public async Task Handle(CreateMetricCommand command)
    {
        var types = new Dictionary<int, string>
        {
            { 1, "Changed Humidity" },
            { 2, "Changed Light" },
            { 3, "Changed Temperature " },
            { 4, "Changed Water Consumption" }
        };
        var token = currentSession.HttpContext?.Request.Headers["Authorization"].ToString();
        var payload = new JwtSecurityTokenHandler().ReadJwtToken(token?.Replace("Bearer ", ""));
        if (payload == null)
        {
            throw new UnauthorizedAccessException("Invalid token.");
        }
        var userId = payload.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            throw new UnauthorizedAccessException("The 'Sid' claim is missing or invalid.");
        }
        var metric = new Metric(command.MetricValue, command.MetricTypesId, command.DeviceId);
        await metricRepository.AddAsync(metric);
        await notificationService.CreateNotification(types[command.MetricTypesId], "A new status has been recorded for your plant", int.Parse(userId));
        await unitOfWork.CompleteAsync();
    }
}

