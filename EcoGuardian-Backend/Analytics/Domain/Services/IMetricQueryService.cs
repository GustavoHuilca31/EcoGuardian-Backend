using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;

namespace EcoGuardian_Backend.Analytics.Domain.Services;

public interface IMetricQueryService
{
    Task<IEnumerable<Metric>> Handle(GetMetricsByDeviceIdQuery query);
    Task<IEnumerable<Metric>> Handle(GetMetricsByDeviceIdAndMetricTypeIdQuery query);
    Task<Metric?> GetLatestMetricByDeviceIdAsync(int deviceId);
    Task<Metric?> GetLatestMetricByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId);
    Task<IEnumerable<Metric>> GetLastNMetricsByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId, int n);
}