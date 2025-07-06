using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Analytics.Interfaces.REST.Transform;

public static class MetricRegistryResourceFromEntityAssembler
{
    public static MetricRegistryResource ToResourceFromEntity(MetricRegistry registry)
    {
        return new MetricRegistryResource
        {
            Id = registry.Id,
            DeviceId = registry.DeviceId,
            CreatedAt = registry.CreatedAt,
            Metrics = registry.Metrics.Select(MetricResourceFromEntityAssembler.ToResourceFromEntity).ToList()
        };
    }
}

