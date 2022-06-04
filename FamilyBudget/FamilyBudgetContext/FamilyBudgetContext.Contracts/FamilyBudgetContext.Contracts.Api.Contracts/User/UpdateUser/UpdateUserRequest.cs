namespace FamilyBudgetContext.Contracts.Api.Contracts.User.UpdateUser;

public class UpdateUserRequest
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public string? Email { get; set; }
        
    public string? Password { get; set; }

    public string? Photo { get; set; }
}