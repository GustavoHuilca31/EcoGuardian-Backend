namespace EcoGuardian_Backend.IAM.Domain.Model.Commands;

public record SignInCommand(string Email, string Password);