using EcoGuardian_Backend.IAM.Domain.Model.Entities;
using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.IAM.Domain.Respositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.IAM.Infrastructure.Persistence.EFC.Respositories;

public class UserRoleRepository(AppDbContext context) : BaseRepository<UserRole>(context), IUserRoleRepository
{
    public async Task<bool> ExistsUserRole(EUserRoles role)
    {
        return await context.Set<UserRole>().AnyAsync(userRole => userRole.Role == role.ToString());
    }
}
