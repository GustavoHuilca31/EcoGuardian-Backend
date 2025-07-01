namespace EcoGuardian_Backend.Resources.Domain.Model.Commands;

public record UpdateDeviceCommand(
    int Id,
    string Type,
    decimal Voltage,
    int DeviceStateId,
    int PlantId);