using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Trasform;

public class NotificationResourceFromEntityAssember
{
    public static NotificationResource ToResourceFromEntityAssembler(Notification notification)
    {
        return new NotificationResource(
            notification.Id,
            notification.Title,
            notification.Subject,
            notification.ProfileId,
            notification.CreatedAt
        );
    }
}