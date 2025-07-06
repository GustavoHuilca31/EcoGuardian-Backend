namespace EcoGuardian_Backend.Resources.Application.Internal.OutBoundServices;

public interface IExternalPlantService
{
    Task<bool> IsPlantExistsAsync(int plantId);
    Task<int> GetUserIdByPlantIdAsync(int plantId);
}