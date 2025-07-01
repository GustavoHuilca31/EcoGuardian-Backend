using System.ComponentModel;

namespace EcoGuardian_Backend.Resources.Domain.Model.ValueObjects;

public enum EDeviceStates
{
    [Description("Activate")]
    Activate = 1,
    [Description("Desactivate")]
    Desacyivate = 2,
}