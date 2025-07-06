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

public class MetricRegistryCommandService(IExternalResourceService externalResourceService, IMetricRegistryRepository metricRegistryRepository, IExternalNotificationService notificationService, IUnitOfWork unitOfWork, IExternalPlantEvaluatedService externalPlantEvaluatedService) : IMetricRegistryCommandService
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
            var plantId = await externalResourceService.GetPlantIdByDeviceIdAsync(command.DeviceId);
            var threshold = await externalPlantEvaluatedService.GetPlantThresholdByPlantIdAndMetricType(plantId,metricCmd.MetricTypesId);
            if (types.TryGetValue(metricCmd.MetricTypesId, out var typeName))
            {
                if (double.Parse(metricCmd.MetricValue.ToString()) > threshold)
                {
                    await notificationService.CreateNotification(typeName, "Metric data has surpased threshold!", userId);
                }
            }
        }
        await unitOfWork.CompleteAsync();
    }
}
