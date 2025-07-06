using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;

public class Profile
{
    public int Id { get; }

    public string Name { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Address { get; private set; }

    public string AvatarUrl { get; set; }

    public int UserId { get; private set; }

    public int SubscriptionId { get; private set; }

    public Profile()
    {
        Name = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Address = string.Empty;
        UserId = 0;
        SubscriptionId = 0;
        AvatarUrl = string.Empty;
    }

    public Profile(CreateProfileCommand command)
    {
        this.Name = command.Name;
        this.LastName = command.LastName;
        this.Email = command.Email;
        this.Address = command.Address;
        this.UserId = command.UserId;
        this.SubscriptionId = command.SubscriptionId;
        this.AvatarUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Default_pfp.svg/2048px-Default_pfp.svg.png";
    }

    public void Update(UpdateProfileCommand command)
    {
        this.Name = command.Name;
        this.LastName = command.LastName; // Assuming LastName is part of the command
        this.Address = command.Address;
    }
    
    public void upateImage(string imageUrl)
    {
        this.AvatarUrl = imageUrl;
    }
}