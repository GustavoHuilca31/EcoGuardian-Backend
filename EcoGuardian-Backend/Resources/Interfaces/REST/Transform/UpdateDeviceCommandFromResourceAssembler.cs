using EcoGuardian_Backend.Resources.Domain.Model.Commands;
using EcoGuardian_Backend.Resources.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Resources.Interfaces.REST.Transform;

public static class UpdateDeviceCommandFromResourceAssembler
{
    public static UpdateDeviceCommand ToCommandFromResource(int id, UpdateDeviceResource resource)
    {
        return new UpdateDeviceCommand(
            id,
            resource.Type,
            resource.Voltage,
            resource.DeviceStateId,
            resource.PlantId
        );
    }
}

