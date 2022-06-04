using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyBudgetContext.Application.AppServices.Shared.Helpers;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.Dto;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.JoinChat;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Chat.Service;

public class ChatService : IChatService
{
    private readonly IChatRepository _chatRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ChatService(IChatRepository chatRepository, IMapper mapper, IUserRepository userRepository)
    {
        _chatRepository = chatRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<SendMessageResponse> SendMessage(SendMessageRequest request, CancellationToken cancellation)
    {
        var message = _mapper.Map<MessageEntity>(request);
        await _chatRepository.AddAsync(message, cancellation);
        
        var sendMessageResponse = _mapper.Map<SendMessageResponse>(request);
        sendMessageResponse.UserName = _userRepository.GetByIdAsync(request.UserId, cancellation).Result.Name;
        sendMessageResponse.Date = message.Date.DateTimeToUnixTimeStamp();
        
        return sendMessageResponse;
    }

    public async Task<JoinChatResponse> JoinChat(JoinChatRequest request, CancellationToken cancellation)
    {
        var messages = await _chatRepository.GetByRoomIdAsync(request.RoomId, cancellation);
        var messageDtos = _mapper.Map<IList<MessageEntity>, IList<MessageDto>>(messages);
        
        foreach (var messageDto in messageDtos)
        {
            messageDto.UserName = _userRepository.GetByIdAsync(messageDto.UserId, cancellation).Result.Name;
        }
        
        return new JoinChatResponse
        {
            Messages = messageDtos
        };
    }
}