namespace EcoGuardian_Backend.Resources.Domain.Model.Entities;

public class DeviceState
{
    public int Id { get; }
    public string Type { get; set; }

    public DeviceState()
    {
        Type = string.Empty;
    }

    public DeviceState(string type)
    {
        Type = type;
    }
}