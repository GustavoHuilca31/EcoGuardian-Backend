using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Queries;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.QueryServices;

public class PlantQueryService(IPlantRepository plantRepository) : IPlantQueryService
{
    public async Task<IEnumerable<Plant>> Handle(GetPlantsByUserIdQuery query)
    {
        return await plantRepository.GetPlantsByUserIdAsync(query.UserId);
    }

    public async Task<Plant> Handle(GetPlantByIdQuery query)
    {
        var plant = await plantRepository.GetByIdAsync(query.Id);
        return plant ?? throw new KeyNotFoundException($"Plant with ID {query.Id} not found.");
    }
}