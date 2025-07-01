using EcoGuardian_Backend.Resources.Domain.Model.Commands;
using EcoGuardian_Backend.Resources.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Resources.Interfaces.REST.Transform;

public static class CreateDeviceCommandFromResourceAssembler
{
    public static CreateDeviceCommand ToCommandFromResource(CreateDeviceResource resource)
    {
       return new CreateDeviceCommand(
            resource.Type,
            resource.Voltage,
            resource.PlantId
        );
    }
}
