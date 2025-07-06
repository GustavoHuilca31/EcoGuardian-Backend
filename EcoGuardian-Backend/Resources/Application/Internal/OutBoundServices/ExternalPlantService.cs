using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL;

namespace EcoGuardian_Backend.Resources.Application.Internal.OutBoundServices;

public class ExternalPlantService(IMonitorinContextFacade monitoringContextFacade) : IExternalPlantService
{
    public async Task<bool> IsPlantExistsAsync(int plantId)
    {
        return await monitoringContextFacade.CheckPlantExists(plantId);
    }

    public async Task<int> GetUserIdByPlantIdAsync(int plantId)
    {
        return await monitoringContextFacade.GetUserIdByPlantIdAsync(plantId);
    }
}