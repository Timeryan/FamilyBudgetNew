using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Room.Dto;

public class UserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Email { get; set; }
        
    public string? Photo { get; set; }
    public UserRoleInRoomEnum Role { get; set; }
    
    public string? UserColor { get; set; }

}