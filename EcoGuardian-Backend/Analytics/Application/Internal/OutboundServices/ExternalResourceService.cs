using EcoGuardian_Backend.Resources.Application.Internal.OutBoundServices;
using EcoGuardian_Backend.Resources.Interfaces.ACL;

namespace EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;

public class ExternalResourceService(IResourceContextFacade resourceContextFacade) : IExternalResourceService
{
    public async Task<int> GetUserIdByDeviceIdAsync(int deviceId)
    {
        return await resourceContextFacade.GetUserIdByDeviceIdAsync(deviceId);
    }
}

