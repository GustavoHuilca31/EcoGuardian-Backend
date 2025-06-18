using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Analytics.Domain.Repositories;

public interface IMetricRepository : IBaseRepository<Metric>
{
    Task<IEnumerable<Metric>> GetMetricsByDeviceIdAsync(int deviceId);
    Task<IEnumerable<Metric>> GetMetricsByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId);
}
