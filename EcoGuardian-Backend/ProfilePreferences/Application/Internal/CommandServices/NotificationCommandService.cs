using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Services;
using EcoGuardian_Backend.ProfilePreferences.Domain.Repositories;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace EcoGuardian_Backend.ProfilePreferences.Application.Internal.CommandServices;

public class NotificationCommandService(INotificationRepository notificationRepository, IProfileRepository profileRepository, IUnitOfWork unitOfWork) : INotificationCommandService
{
    public async Task Handle(CreateNotificationCommand command)
    {
        var profileExists = await profileRepository.GetByIdAsync(command.ProfileId);
        if (profileExists == null)
        {
            throw new InvalidDataException($"Profile with id {command.ProfileId} does not exist.");
        }
        var notification = new Notification(command);
        await notificationRepository.AddAsync(notification);
        await unitOfWork.CompleteAsync();
    }
}