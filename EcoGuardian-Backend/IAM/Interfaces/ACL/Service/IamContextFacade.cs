using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Domain.Model.Queries;
using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.IAM.Domain.Services;

namespace EcoGuardian_Backend.IAM.Interfaces.ACL.Service;

public class IamContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IIamContextFacade
{
    public async Task<int> CreateUser(string username, string password,string email, EUserRoles Role )
    {
        var signUpCommand = new SignUpCommand(username, password,email, Role);
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByEmailQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }
    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByEmailQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }

    public bool UsersExists(int userId)
    {
        return userQueryService.Handle(new UserExistsQuery(userId));
    }
}