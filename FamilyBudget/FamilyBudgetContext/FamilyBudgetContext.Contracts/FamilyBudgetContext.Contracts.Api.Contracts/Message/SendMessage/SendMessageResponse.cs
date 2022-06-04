using System.Collections.Generic;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.Dto;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;

public class SendMessageResponse
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Text { get; set; }
    
    public long Date { get; set; }
}