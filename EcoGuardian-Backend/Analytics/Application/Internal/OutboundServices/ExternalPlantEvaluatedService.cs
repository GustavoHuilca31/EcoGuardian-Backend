using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL;

namespace EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;

public class ExternalPlantEvaluatedService(IMonitorinContextFacade monitoringContextFacade) : IExternalPlantEvaluatedService
{
    public async Task<double> GetPlantThresholdByPlantIdAndMetricType(int plantId, int metricTypeId)
    {
       return await monitoringContextFacade.GetPlantThresholdByPlantId(plantId, metricTypeId);
    }
}