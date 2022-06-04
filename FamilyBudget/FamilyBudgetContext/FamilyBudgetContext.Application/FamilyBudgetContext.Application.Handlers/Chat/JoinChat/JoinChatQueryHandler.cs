using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Chat.Service;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.JoinChat;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Chat.JoinChat
{
    public class JoinChatQueryHandler : IRequestHandler<JoinChatQuery, JoinChatResponse>
    {
		private readonly IChatService _chatService;

		public JoinChatQueryHandler(
			IChatService chatService)
		{
			_chatService = chatService;
		}
		
		public Task<JoinChatResponse> Handle(JoinChatQuery request, CancellationToken cancellation)
		{
			return _chatService.JoinChat(request.Request, cancellation);
		}
    }
}
