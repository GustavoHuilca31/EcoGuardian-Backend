using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Analytics.Infrastructure.Persistence.EFC.Repositories;

public class MetricRepository(AppDbContext context) : BaseRepository<Metric>(context), IMetricRepository
{
    public async Task<IEnumerable<Metric>> GetMetricsByDeviceIdAsync(int deviceId)
    {
        return await context.Set<Metric>()
            .Where(x => x.DeviceId == deviceId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Metric>> GetMetricsByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId)
    {
        return await context.Set<Metric>()
            .Where(x => x.DeviceId == deviceId && x.MetricTypesId == metricTypeId)
            .ToListAsync();
    }

    public async Task<Metric?> GetLatestMetricByDeviceIdAsync(int deviceId)
    {
        return await context.Set<Metric>()
            .Where(x => x.DeviceId == deviceId)
            .OrderByDescending(x => x.CreatedAt)
            .FirstOrDefaultAsync();
    }

    public async Task<Metric?> GetLatestMetricByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId)
    {
        return await context.Set<Metric>()
            .Where(x => x.DeviceId == deviceId && x.MetricTypesId == metricTypeId)
            .OrderByDescending(x => x.CreatedAt)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Metric>> GetLastNMetricsByDeviceIdAndMetricTypeIdAsync(int deviceId, int metricTypeId, int n)
    {
        return await context.Set<Metric>()
            .Where(x => x.DeviceId == deviceId && x.MetricTypesId == metricTypeId)
            .OrderByDescending(x => x.CreatedAt)
            .Take(n)
            .ToListAsync();
    }
}
