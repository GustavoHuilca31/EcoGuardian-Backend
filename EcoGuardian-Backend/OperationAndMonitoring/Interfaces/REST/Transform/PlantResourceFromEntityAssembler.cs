using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;

public class PlantResourceFromEntityAssembler
{
    public static PlantResource ToResourceFromEntity(Plant plant)
    {
        return new PlantResource
        {
            Id = plant.Id,
            Name = plant.Name,
            Type = plant.Type,
            AreaCoverage = plant.AreaCoverage,
            UserId = plant.UserId,
            WaterThreshold = plant.WaterThreshold,
            LightThreshold = plant.LightThreshold,
            TemperatureThreshold = plant.TemperatureThreshold,
            CreatedAt = plant.CreatedAt,
            UpdatedAt = plant.UpdatedAt,
            IsPlantation = plant.IsPlantation,
            WellnessStateId = plant.WellnessStateId,
            Image = plant.Image
        };
    }
}