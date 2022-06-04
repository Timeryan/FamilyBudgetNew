using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Chat.Service;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Chat.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, SendMessageResponse>
    {
        private readonly IChatService _chatService;

        public SendMessageCommandHandler(
            IChatService chatService)
        {
            _chatService = chatService;
        }

        public Task<SendMessageResponse> Handle(SendMessageCommand command, CancellationToken cancellation)
        {
            return _chatService.SendMessage(command.Request, cancellation);
        }
    }
}