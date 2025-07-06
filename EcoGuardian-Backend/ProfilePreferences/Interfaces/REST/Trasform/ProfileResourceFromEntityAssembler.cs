using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Trasform;

public class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResourceFromEntity(Profile entity)
    {
        return new ProfileResource(
            entity.Id,
            entity.Name,
            entity.LastName,
            entity.Email,
            entity.Address,
            entity.AvatarUrl,
            entity.UserId,
            entity.SubscriptionId
        );
    }
}