using Common.Domain.Domain;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;

namespace FamilyBudgetContext.Domain.Domain;

public class RoomToUserEntity : Entity
{
    public int UserId { get; set; }
    
    public virtual UserEntity? User { get; set; }

    public int RoomId { get; set; }
    
    public virtual RoomEntity? Room { get; set; }

    public UserRoleInRoomEnum Role { get; set; }
    public string? UserColor { get; set; }
}