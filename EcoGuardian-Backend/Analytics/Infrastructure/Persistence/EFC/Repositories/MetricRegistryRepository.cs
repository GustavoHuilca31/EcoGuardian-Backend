using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Analytics.Infrastructure.Persistence.EFC.Repositories;

public class MetricRegistryRepository(AppDbContext context) : BaseRepository<MetricRegistry>(context), IMetricRegistryRepository
{
    public async Task<IEnumerable<MetricRegistry>> GetMetricRegistriesByDeviceIdAsync(int deviceId)
    {
        return await context.Set<MetricRegistry>()
            .Include(r => r.Metrics)
            .Where(r => r.DeviceId == deviceId)
            .OrderBy(r => r.CreatedAt)
            .ToListAsync();
    }

    public async Task<MetricRegistry?> GetLatestMetricRegistryByDeviceIdAsync(int deviceId)
    {
        return await context.Set<MetricRegistry>()
            .Include(r => r.Metrics)
            .Where(r => r.DeviceId == deviceId)
            .OrderByDescending(r => r.CreatedAt)
            .FirstOrDefaultAsync();
    }
}

