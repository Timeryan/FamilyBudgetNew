namespace FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;

public class RegisterUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public string? Photo { get; set; }
}