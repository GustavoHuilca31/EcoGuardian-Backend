namespace EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;

public class Metric
{
    public int Id { get; private set; }
    public decimal MetricValue { get; private set; }
    public int MetricTypesId { get; private set; }
    public int DeviceId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Metric(decimal metricValue, int metricTypesId, int deviceId)
    {
        MetricValue = metricValue;
        MetricTypesId = metricTypesId;
        DeviceId = deviceId;
        CreatedAt = DateTime.UtcNow;
    }

    private Metric() { }
}