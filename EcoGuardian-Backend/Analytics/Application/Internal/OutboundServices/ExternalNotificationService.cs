using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.ACL;

namespace EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;

public class ExternalNotificationService(INotificationServiceFacade notificationServiceFacade) : IExternalNotificationService
{
    public async Task<bool> CreateNotification(string title, string subject, int profileId)
    {
        return await notificationServiceFacade.CreateNotificationAsync(title, subject, profileId);
    }
}