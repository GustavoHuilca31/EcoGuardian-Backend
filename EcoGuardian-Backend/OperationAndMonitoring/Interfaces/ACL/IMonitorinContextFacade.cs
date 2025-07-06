namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL;

public interface IMonitorinContextFacade
{
    Task<bool> CheckPlantExists(int plantId);
    void UpdatePlantState(int stateId, int plantId);
    Task<int> GetUserIdByPlantIdAsync(int plantId);
}