using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Analytics.Domain.Repositories;

public interface IMetricRegistryRepository : IBaseRepository<MetricRegistry>
{
    Task<IEnumerable<MetricRegistry>> GetMetricRegistriesByDeviceIdAsync(int deviceId);
    Task<MetricRegistry?> GetLatestMetricRegistryByDeviceIdAsync(int deviceId);
}

