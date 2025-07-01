namespace EcoGuardian_Backend.Resources.Interfaces.REST.Resources;

public record DeviceResource
{
    public int Id { get; set; }
    public string Type { get; set; }
    public decimal Voltage { get; set; }
    public int? DeviceStateId { get; set; }
    public int PlantId { get; set; }
    public DateTime? ActivatedAt { get; set; }
    public DateTime? DeactivatedAt { get; set; }
};

