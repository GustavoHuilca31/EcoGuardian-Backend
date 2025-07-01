using System.Threading.Tasks;
using EcoGuardian_Backend.Resources.Domain.Model.Commands;

namespace EcoGuardian_Backend.Resources.Domain.Services;

public interface IDeviceCommandService
{
    Task Handle(CreateDeviceCommand command);
    Task Handle(UpdateDeviceStatusCommand command);
    Task Handle(UpdateDeviceCommand command);
}

