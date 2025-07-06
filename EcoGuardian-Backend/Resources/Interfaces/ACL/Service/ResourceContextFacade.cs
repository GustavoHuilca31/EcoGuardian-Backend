using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL;
using EcoGuardian_Backend.Resources.Application.Internal.OutBoundServices;
using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Domain.Model.Queries;
using EcoGuardian_Backend.Resources.Domain.Services;

namespace EcoGuardian_Backend.Resources.Interfaces.ACL.Service;

public class ResourceContextFacade(IDeviceQueryService deviceQueryService, IExternalPlantService externalPlantService) : IResourceContextFacade
{
    public async Task<int> GetPlantIdByDeviceIdAsync(int deviceId)
    {
        var query = new GetPlantIdByIdQuery(deviceId);
        return await deviceQueryService.Handle(query);
    }
    
    public async Task<int> GetUserIdByDeviceIdAsync(int deviceId)
    {
        var plantId = await GetPlantIdByDeviceIdAsync(deviceId);
        return await externalPlantService.GetUserIdByPlantIdAsync(plantId);
    }
}