using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Analytics.Interfaces.REST.Transform;

public static class MetricResourceFromEntityAssembler
{
    public static MetricResource ToResourceFromEntity(Metric metric)
    {
        return new MetricResource
        {
            Id = metric.Id,
            MetricValue = metric.MetricValue,
            MetricTypesId = metric.MetricTypesId,
            DeviceId = metric.DeviceId,
            CreatedAt = metric.CreatedAt
        };
    }
}
