using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Resources.Interfaces.REST.Transform;

public static class DeviceResourceFromEntityAssembler
{
    public static DeviceResource ToResourceFromEntity(Device device)
    {
        return new DeviceResource
        {
            Id = device.Id,
            Type = device.Type,
            Voltage = device.Voltage,
            DeviceStateId = device.DeviceStateId,
            PlantId = device.PlantId,
            ActivatedAt = device.ActivatedAt,
            DeactivatedAt = device.DeactivatedAt
        };
    }
}

