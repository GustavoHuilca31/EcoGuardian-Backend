using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace EcoGuardian_Backend.Resources.Infrastructure.Persistence.EFC.Repositories;

public class DeviceRepository(AppDbContext context) :BaseRepository<Device>(context), IDeviceRepository
{
    public async Task<IEnumerable<Device>> GetByPlantIdAsync(int plantId)
    {
        return await context.Set<Device>()
            .Where(d => d.PlantId == plantId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Device>> GetAllDevicesAsync()
    {
        return await context.Set<Device>()
            .ToListAsync();
    }
}
