using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Analytics.Interfaces.REST.Transform;

public static class CreateMetricRegistryCommandFromResourceAssembler
{
    public static CreateMetricRegistryCommand ToCommandFromResource(CreateMetricRegistryResource resource)
    {
        var metrics = resource.Metrics.Select(m => new CreateMetricCommand(m.MetricValue, m.MetricTypesId)).ToList();
        return new CreateMetricRegistryCommand(resource.DeviceId, metrics);
    }
}

