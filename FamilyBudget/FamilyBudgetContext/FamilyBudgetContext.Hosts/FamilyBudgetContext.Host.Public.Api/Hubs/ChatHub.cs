using System.Net;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.Handlers.Chat.JoinChat;
using FamilyBudgetContext.Application.Handlers.Chat.SendMessage;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.JoinChat;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace FamilyBudgetContext.Host.Public.Api.Hubs;

/// <summary>
/// Хаб для работы с чатом.
/// </summary>
[Produces("application/json")]
[SignalRHub]
public class ChatHub : Hub
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Иницилизирует экзепляр класса <see cref="ChatHub"/>.
    /// </summary>
    /// <param name="mediator">Медиатор.</param>
    public ChatHub(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Метод отправка сообщения.
    /// </summary>
    /// <param name="request">Данные сообщения.</param>
    [ProducesResponseType(typeof(SendMessageResponse), (int)HttpStatusCode.OK)]
    public async Task Send(SendMessageRequest request)
    {
        var message = await _mediator.Send(new SendMessageCommand(request));
        await Clients.Group(request.RoomId.ToString()).SendAsync("Send", message);
    }
    
    /// <summary>
    /// Метод присоединения к чату.
    /// </summary>
    /// <param name="request">Индитификатор комнаты.</param>
    [ProducesResponseType(typeof(JoinChatResponse), (int)HttpStatusCode.OK)]
    public async Task Join(JoinChatRequest request)
    {
        var messageHistory = await _mediator.Send(new JoinChatQuery(request));
        await Groups.AddToGroupAsync(Context.ConnectionId,  request.RoomId.ToString());
        await Clients.Caller.SendAsync("Join", messageHistory.Messages);
    }
}