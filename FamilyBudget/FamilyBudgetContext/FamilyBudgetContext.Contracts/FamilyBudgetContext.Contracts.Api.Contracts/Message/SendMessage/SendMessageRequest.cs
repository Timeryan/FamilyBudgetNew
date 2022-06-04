namespace FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;

public class SendMessageRequest
{
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }
}