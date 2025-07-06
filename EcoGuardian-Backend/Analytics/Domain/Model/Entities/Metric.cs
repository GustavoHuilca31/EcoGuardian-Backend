namespace EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;

public class Metric
{
    public int Id { get; private set; }
    public decimal MetricValue { get; private set; }
    public int MetricTypesId { get; private set; }
    public int MetricRegistryId { get; private set; }
    public MetricRegistry MetricRegistry { get; private set; }

    public Metric(decimal metricValue, int metricTypesId, int metricRegistryId)
    {
        MetricValue = metricValue;
        MetricTypesId = metricTypesId;
        MetricRegistryId = metricRegistryId;
    }

    private Metric() { }
}