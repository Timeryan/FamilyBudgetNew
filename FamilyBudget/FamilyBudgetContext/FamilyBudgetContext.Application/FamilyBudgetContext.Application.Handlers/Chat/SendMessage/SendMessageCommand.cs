using FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Chat.SendMessage
{
    public class SendMessageCommand : IRequest<SendMessageResponse>
    {
        public SendMessageRequest Request { get; set; }

        public SendMessageCommand(SendMessageRequest request)
        {
            Request = request;
        }
    }
}
