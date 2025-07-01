namespace EcoGuardian_Backend.Analytics.Application.Internal.OutboundServices;

public interface IExternalNotificationService
{
    Task<bool> CreateNotification(string title, string subject, int profileId);
}