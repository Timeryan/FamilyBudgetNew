using System.Collections.Generic;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.Dto;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Message.JoinChat
{
    public class JoinChatResponse
    {
        public IList<MessageDto> Messages { get; set; }
    }
}