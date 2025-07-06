using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.Resources.Interfaces.ACL;

public interface IResourceContextFacade
{
    Task<int> GetPlantIdByDeviceIdAsync(int deviceId);
    Task<int> GetUserIdByDeviceIdAsync(int deviceId);
}