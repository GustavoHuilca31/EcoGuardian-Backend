namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

public record PlantResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int AreaCoverage { get; set; }
    public int UserId { get; set; }
    public double WaterThreshold { get; set; }
    public double LightThreshold { get; set; }
    public double TemperatureThreshold { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsPlantation { get; set; }
    public int WellnessStateId { get; set; }
    public string Image { get; set; } // URL de la imagen de la planta
};