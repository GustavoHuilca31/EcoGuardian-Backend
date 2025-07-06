namespace EcoGuardian_Backend.Analytics.Interfaces.REST.Resources;

public record MetricResource
{
    public int Id { get; set; }
    public decimal MetricValue { get; set; }
    public int MetricTypesId { get; set; }
}
