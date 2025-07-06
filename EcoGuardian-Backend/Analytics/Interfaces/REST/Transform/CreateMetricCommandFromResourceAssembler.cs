using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Analytics.Interfaces.REST.Transform;

public static class CreateMetricCommandFromResourceAssembler
{
    public static CreateMetricCommand ToCommandFromResource(CreateMetricResource resource)
    {
        return new CreateMetricCommand(
            resource.MetricValue,
            resource.MetricTypesId
        );
    }
}
