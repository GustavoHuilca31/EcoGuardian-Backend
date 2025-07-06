using System.Resources;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;

public class CreatePlantCommandFromResourceAssembler
{
    public static CreatePlantCommand ToCommandFromResource(CreatePlantResource resource)
    {
        return new CreatePlantCommand(
            resource.Name,
            resource.Image,
            resource.Type,
            resource.AreaCoverage,
            resource.UserId,
            resource.WaterThreshold,
            resource.LightThreshold,
            resource.TemperatureThreshold,
            resource.IsPlantation,
            resource.WellnessStateId
        );
    }
}