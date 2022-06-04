using FamilyBudgetContext.Contracts.Api.Contracts.Message.JoinChat;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Chat.JoinChat
{
    public class JoinChatQuery : IRequest<JoinChatResponse>
    {
        public JoinChatRequest Request { get; set; }

        public JoinChatQuery(JoinChatRequest request)
        {
            Request = request;
        }
    }
}
