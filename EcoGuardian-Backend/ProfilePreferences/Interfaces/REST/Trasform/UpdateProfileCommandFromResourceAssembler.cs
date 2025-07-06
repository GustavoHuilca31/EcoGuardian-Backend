using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Trasform;

public class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommandFromResource(int id, UpdateProfileResource resource)
    {
        return new UpdateProfileCommand(
            id,
            resource.Name,
            resource.LastName,
            resource.Address,
            resource.AvatarUrl
        );
    }
}