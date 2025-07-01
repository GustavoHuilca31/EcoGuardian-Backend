using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;

namespace EcoGuardian_Backend.Analytics.Application.Internal.QueryServices;

public class MetricQueryService(IMetricRepository metricRepository) : IMetricQueryService
{
    public async Task<IEnumerable<Metric>> Handle(GetMetricsByDeviceIdQuery query)
    {
        return await metricRepository.GetMetricsByDeviceIdAsync(query.DeviceId);
    }

    public async Task<IEnumerable<Metric>> Handle(GetMetricsByDeviceIdAndMetricTypeIdQuery query)
    {
        return await metricRepository.GetMetricsByDeviceIdAndMetricTypeIdAsync(query.DeviceId, query.MetricTypeId);
    }

    public async Task<Metric?> GetLatestMetricByDeviceIdAsync(int deviceId)
    {
        return await metricRepository.GetLatestMetricByDeviceIdAsync(deviceId);
    }

    public async Task<Metric?> GetLatestMetricByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId)
    {
        return await metricRepository.GetLatestMetricByDeviceIdAndMetricTypeIdAsync(deviceId, metricTypeId);
    }

    public async Task<IEnumerable<Metric>> GetLastNMetricsByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId, int n)
    {
        return await metricRepository.GetLastNMetricsByDeviceIdAndMetricTypeIdAsync(deviceId, metricTypeId, n);
    }
}
