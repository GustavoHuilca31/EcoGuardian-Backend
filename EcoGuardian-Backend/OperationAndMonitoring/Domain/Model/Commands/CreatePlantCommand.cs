namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

public record CreatePlantCommand(
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