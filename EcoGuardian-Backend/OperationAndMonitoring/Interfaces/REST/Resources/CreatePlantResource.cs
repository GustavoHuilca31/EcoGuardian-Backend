namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

public record CreatePlantResource(
    string Name,
    IFormFile Image,
    string Type,
    int AreaCoverage,
    int UserId,
    double WaterThreshold,
    double LightThreshold,
    double TemperatureThreshold,
    bool IsPlantation,
    int WellnessStateId
    );