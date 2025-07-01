using EcoGuardian_Backend.Resources.Domain.Model.Commands;

namespace EcoGuardian_Backend.Resources.Domain.Model.Aggregates;

public class Device
{
    public int Id { get;  }
    public decimal Voltage { get; set; }
    
    public string Type { get; set; }
    
    public int? DeviceStateId { get; set; }
    public int PlantId { get; set; }
    
    public DateTime? ActivatedAt { get; set; }
    public DateTime? DeactivatedAt { get; set; }


    public Device()
    {
        Voltage = 0;
        Type = string.Empty;
        DeviceStateId = 0;
        PlantId = 0;
        DeactivatedAt = null;
        
    }
    
    public Device(CreateDeviceCommand command)
    {
        Voltage = command.Voltage;
        Type = command.Type;
        PlantId = command.PlantId;
        DeactivatedAt = null;
    }
    
    public void Update(UpdateDeviceCommand command)
    {
        Voltage = command.Voltage;
        Type = command.Type;
        PlantId = command.PlantId;
    }
    
    public void Desactivate(UpdateDeviceStatusCommand command)
    {
        DeactivatedAt = DateTime.UtcNow;
        DeviceStateId = command.StatusId;
    }
    
    public void Activate(UpdateDeviceStatusCommand command)
    {
        DeactivatedAt = null;
        DeviceStateId = command.StatusId;
        ActivatedAt = DateTime.UtcNow;
    }
    
    
}
