namespace FamilyBudgetContext.Contracts.Api.Contracts.Message.Dto;

public class MessageDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Text { get; set; }
    public long Date { get; set; }
}