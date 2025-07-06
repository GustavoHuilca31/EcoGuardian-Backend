using EcoGuardian_Backend.Resources.Application.Internal.OutBoundServices;
using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Domain.Model.Commands;
using EcoGuardian_Backend.Resources.Domain.Repositories;
using EcoGuardian_Backend.Resources.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Resources.Application.Internal.CommandServices;

public class DeviceCommandService : IDeviceCommandService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExternalPlantService _externalPlantService;

    public DeviceCommandService(
        IDeviceRepository deviceRepository, 
        IUnitOfWork unitOfWork,
        IExternalPlantService externalPlantService
        )
    {
        _deviceRepository = deviceRepository;
        _unitOfWork = unitOfWork;
        _externalPlantService = externalPlantService;
    }


    public async Task<Device> Handle(CreateDeviceCommand command)
    {
        var isPlantExists = await _externalPlantService.IsPlantExistsAsync(command.PlantId);
        if (!isPlantExists)
        {
            throw new ArgumentException($"Plant with ID {command.PlantId} does not exist.");
        }

        var device = new Device(command);
        await _deviceRepository.AddAsync(device);
        await _unitOfWork.CompleteAsync();
        
        return device;
    }

    public async Task Handle(UpdateDeviceStatusCommand command)
    {
        var device = await _deviceRepository.GetByIdAsync(command.Id);
        if (device == null)
        {
            throw new ArgumentException($"Device with ID {command.Id} does not exist.");
        }

        if (command.StatusId == 1)
        {
            device.Activate(command);
        }
        else
        {
            device.Desactivate(command);
        }
        _deviceRepository.Update(device);
        await _unitOfWork.CompleteAsync();
        
    }

    public async Task Handle(UpdateDeviceCommand command)
    {
        var isPlantExists = await _externalPlantService.IsPlantExistsAsync(command.PlantId);
        if (!isPlantExists)
        {
            throw new ArgumentException($"Plant with ID {command.PlantId} does not exist.");
        }
        var device = await _deviceRepository.GetByIdAsync(command.Id);
        if (device == null)
        {
            throw new ArgumentException($"Device with ID {command.Id} does not exist.");
        }

        device.Update(command);
        _deviceRepository.Update(device);
        await _unitOfWork.CompleteAsync();
    }
}

