namespace EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;

public interface IExternalPlantEvaluatedService
{
    Task<double> GetPlantThresholdByPlantIdAndMetricType(int plantId, int metricTypeId);
}