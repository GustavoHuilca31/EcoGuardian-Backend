namespace EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;

public record CreateProfileCommand(string Email, string Name,string LastName, string Address, string AvatarUrl, int UserId, int SubscriptionId);