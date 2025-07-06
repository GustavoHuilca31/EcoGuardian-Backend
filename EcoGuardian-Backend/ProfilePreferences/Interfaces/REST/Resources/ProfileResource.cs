namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

public record ProfileResource(int Id, string Name, string LastName, string Email, string Address, string AvatarUrl, int UserId, int SubscriptionId);