using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.IAM.Domain.Respositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync (string email);
    
    bool ExistsById(int userId);
}