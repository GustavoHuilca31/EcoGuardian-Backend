namespace EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;

public interface IExternalResourceService
{
    Task<int> GetUserIdByDeviceIdAsync(int deviceId);
}

