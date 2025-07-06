using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.ProfilePreferences.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public async Task<Profile?> GetProfileByEmailAsync(string email)
    {
        return await context.Set<Profile>()
            .SingleOrDefaultAsync(p => p.Email == email);
    }

    public bool IsEmailExists(string email)
    {
        return context.Set<Profile>().Any(p => p.Email == email);
    }

    public bool IsUserNameExists(string userName)
    {
        return context.Set<Profile>().Any(p => p.Name + p.Email + p.LastName == userName);
    }
}
