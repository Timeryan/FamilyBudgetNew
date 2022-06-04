namespace FamilyBudgetContext.Contracts.Api.Contracts.Room.UpdateRoom;

public class UpdateRoomRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Photo { get; set; }
}