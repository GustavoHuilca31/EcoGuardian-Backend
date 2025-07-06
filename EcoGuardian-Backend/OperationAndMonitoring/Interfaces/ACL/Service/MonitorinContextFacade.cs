using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Queries;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL.Service;

public class MonitorinContextFacade(IPlantCommandService plantCommandService, IPlantQueryService plantQueryService) : IMonitorinContextFacade
{
    public async Task<bool> CheckPlantExists(int plantId)
    {
        var query = new GetPlantByIdQuery(plantId);
        var exists = await plantQueryService.Handle(query);
        if (exists == null)
        {
            return false;
        }
        return true;
    }

    public void UpdatePlantState(int stateId, int plantId)
    {
        var command = new UpdatePlantStateCommand(stateId, plantId);
        plantCommandService.Handle(command);
    }

    public async Task<int> GetUserIdByPlantIdAsync(int plantId)
    {
        var query = new GetPlantByIdQuery(plantId);
        var plant = await plantQueryService.Handle(query);
        if (plant == null)
        {
            throw new KeyNotFoundException($"Plant with ID {plantId} not found.");
        }
        return plant.UserId;
    }
}