namespace EcoGuardian_Backend.Resources.Interfaces.REST.Resources;

public record CreateDeviceResource(
    string Type,
    decimal Voltage,
    int PlantId
);
