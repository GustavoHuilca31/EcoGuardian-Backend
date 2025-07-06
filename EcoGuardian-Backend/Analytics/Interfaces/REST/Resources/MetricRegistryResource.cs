namespace EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;

public record MetricRegistryResource
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<MetricResource> Metrics { get; set; } = new();
}

