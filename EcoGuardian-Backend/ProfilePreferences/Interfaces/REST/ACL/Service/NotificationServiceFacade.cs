using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Services;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.ACL.Service;

public class NotificationServiceFacade(INotificationCommandService notificationCommandService) : INotificationServiceFacade
{
    public async Task<bool> CreateNotificationAsync(string title, string subject, int profileId)
    {
        var command = new CreateNotificationCommand(title, subject, profileId);
        await notificationCommandService.Handle(command);
        return true;
    }
}