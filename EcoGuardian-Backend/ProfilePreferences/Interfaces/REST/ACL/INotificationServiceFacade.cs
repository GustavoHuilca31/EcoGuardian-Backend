namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.ACL;

public interface INotificationServiceFacade
{
    Task<bool> CreateNotificationAsync(string title, string subject, int profileId);
}