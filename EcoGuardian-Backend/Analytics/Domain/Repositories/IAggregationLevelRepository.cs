using EcoGuardian_Backend.Analytics.Domain.Model.Entities;

namespace EcoGuardian_Backend.Analytics.Domain.Repositories;

public interface IAggregationLevelRepository
{
    Task<bool> IsAggregationLevelExistsAsync(string value);
    Task AddAsync(AggregationLevel aggregationLevel);
    Task<AggregationLevel?> GetByValueAsync(string value);
    Task<AggregationLevel?> GetByIdAsync(int id);
    Task<List<AggregationLevel>> GetAllAsync();
}

