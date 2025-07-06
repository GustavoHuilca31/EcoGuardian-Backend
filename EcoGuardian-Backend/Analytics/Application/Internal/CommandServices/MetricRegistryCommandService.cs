using EcoGuardian_Backend.Resources.Application.Internal.OutBoundServices;
using EcoGuardian_Backend.Resources.Interfaces.ACL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;
using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Analytics.Application.Internal.CommandServices;

public class MetricRegistryCommandService(IExternalResourceService externalResourceService, IMetricRegistryRepository metricRegistryRepository, IExternalNotificationService notificationService, IUnitOfWork unitOfWork) : IMetricRegistryCommandService
{
    public async Task Handle(CreateMetricRegistryCommand command)
    {
        var types = new Dictionary<int, string>
        {
            { 1, "Changed Humidity" },
            { 2, "Changed Light" },
            { 3, "Changed Temperature " },
            { 4, "Changed Water Consumption" }
        };
        var userId = await externalResourceService.GetUserIdByDeviceIdAsync(command.DeviceId);

        Console.WriteLine($" =============== User ID: {userId} ===================");

        var metricRegistry = new MetricRegistry(command.DeviceId);
        foreach (var metricCmd in command.Metrics)
        {
            var metric = new Metric(metricCmd.MetricValue, metricCmd.MetricTypesId, metricRegistry.Id);
            metricRegistry.Metrics.Add(metric);
        }
        await metricRegistryRepository.AddAsync(metricRegistry);
        foreach (var metricCmd in command.Metrics)
        {
            if (types.TryGetValue(metricCmd.MetricTypesId, out var typeName))
            {
                await notificationService.CreateNotification(typeName, "A new status has been recorded for your plant, USER:", userId);
            }
        }
        await unitOfWork.CompleteAsync();
    }
}
