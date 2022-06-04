using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.JoinChat;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;

namespace FamilyBudgetContext.Application.AppServices.Chat.Service;

public interface IChatService
{
    Task<SendMessageResponse> SendMessage(SendMessageRequest request, CancellationToken cancellation);
    Task<JoinChatResponse> JoinChat(JoinChatRequest requestRequest, CancellationToken cancellation);
}