using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.OutboundServices;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.Shared.Application.Internal.CloudinaryStorage;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;

public class PlantCommandService(IPlantRepository plantRepository, IExternalUserService externalUserService, IUnitOfWork unitOfWork, ICloudinaryStorage cloudinaryStorage) : IPlantCommandService
{
    public async Task<Plant> Handle(CreatePlantCommand command)
    {
        var userExists = await externalUserService.CheckUserExists(command.UserId);
        if (!userExists)
        {
            throw new BadHttpRequestException($"User with ID {command.UserId} does not exist.");
        }
        var plant = new Plant(command);
        {
            var imageUploadParams = new ImageUploadParams
            {
                File = new FileDescription(command.Image.FileName, command.Image.OpenReadStream()),
                PublicId = $"{command.UserId}/{command.Name}",
                Transformation = new Transformation().Width(500).Height(500).Crop("fill").Quality("auto"),
                Overwrite = true,
                AllowedFormats = ["jpg", "png", "gif", "webp"],
           };

            await cloudinaryStorage.UploadImage(imageUploadParams);
            var url = await cloudinaryStorage.GetImage($"{command.UserId}/{command.Name}");
            plant.Image = url ?? string.Empty;
        }
        await plantRepository.AddAsync(plant);
        await unitOfWork.CompleteAsync();
        
        return plant;
    }

    public async Task Handle(UpdatePlantCommand command)
    {
        var userExists = await externalUserService.CheckUserExists(command.UserId);
        if (!userExists)
        {
            throw new BadHttpRequestException($"User with ID {command.UserId} does not exist.");
        }
        var plant = await plantRepository.GetByIdAsync(command.Id);
        if (plant == null)
        {
            throw new BadHttpRequestException($"Plant with ID {command.Id} not found.");
        }

        plant.Update(command);
        plantRepository.Update(plant);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(DeletePlantCommand command)
    {
        var plant = await plantRepository.GetByIdAsync(command.Id);
        if (plant == null)
        {
            throw new BadHttpRequestException($"Plant with ID {command.Id} not found.");
        }

        plantRepository.DeleteAsync(plant);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(UpdatePlantStateCommand command)
    {
        var plant = await plantRepository.GetByIdAsync(command.PlantId);
        if (plant == null)
        {
            throw new BadHttpRequestException($"Plant with ID {command.PlantId} not found.");
        }

        plant.UpdateState(command);
        plantRepository.Update(plant);
        await unitOfWork.CompleteAsync();
    }
}