namespace EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;

public record CreateMetricRegistryResource
{
    public int DeviceId { get; set; }
    public List<CreateMetricResource> Metrics { get; set; }
}
