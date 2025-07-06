namespace EcoGuardian_Backend.Analytics.Domain.Model.Commands;

public record CreateMetricCommand(decimal MetricValue, int MetricTypesId);

