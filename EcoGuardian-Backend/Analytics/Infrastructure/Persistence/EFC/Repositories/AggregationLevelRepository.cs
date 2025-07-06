using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace EcoGuardian_Backend.Analytics.Infrastructure.Persistence.EFC.Repositories;

public class AggregationLevelRepository(AppDbContext context) : IAggregationLevelRepository
{
    public async Task<bool> IsAggregationLevelExistsAsync(string value)
    {
        return await context.Set<AggregationLevel>().AnyAsync(x => x.Value == value);
    }

    public async Task AddAsync(AggregationLevel aggregationLevel)
    {
        await context.Set<AggregationLevel>().AddAsync(aggregationLevel);
    }

    public async Task<AggregationLevel?> GetByValueAsync(string value)
    {
        return await context.Set<AggregationLevel>().FirstOrDefaultAsync(x => x.Value == value);
    }

    public async Task<AggregationLevel?> GetByIdAsync(int id)
    {
        return await context.Set<AggregationLevel>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<AggregationLevel>> GetAllAsync()
    {
        return await context.Set<AggregationLevel>().ToListAsync();
    }
}

