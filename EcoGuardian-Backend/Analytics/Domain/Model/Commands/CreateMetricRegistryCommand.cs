namespace EcoGuardian_Backend.Analytics.Domain.Model.Commands;

public record CreateMetricRegistryCommand(int DeviceId, List<CreateMetricCommand> Metrics);
