using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Trasform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(
            resource.Email,
            resource.Name,
            resource.LastName,
            resource.Address, 
            resource.AvatarUrl, 
            resource.UserId, 
            resource.SubscriptionId
        );
    }
}