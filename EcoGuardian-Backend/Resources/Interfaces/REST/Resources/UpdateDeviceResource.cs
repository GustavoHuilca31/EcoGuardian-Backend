namespace EcoGuardian_Backend.Resources.Interfaces.REST.Resources;

public record UpdateDeviceResource(
    string Type,
    decimal Voltage,
    int DeviceStateId,
    int PlantId
);
