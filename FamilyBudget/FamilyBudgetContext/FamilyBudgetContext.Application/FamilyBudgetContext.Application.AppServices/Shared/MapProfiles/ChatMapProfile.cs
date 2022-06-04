using System;
using AutoMapper;
using FamilyBudgetContext.Application.AppServices.Shared.Helpers;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.Dto;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.MapProfiles;

public class ChatMapProfile : Profile
{
    public ChatMapProfile()
    {
        CreateMap<SendMessageRequest, MessageEntity>()
            .ForMember(dest=>dest.Room,opt=>opt.Ignore())
            .ForMember(dest=>dest.User,opt=>opt.Ignore())
            .ForMember(dest=>dest.Id,opt=>opt.Ignore())
            .ForMember(dest=>dest.ModifyDate,opt=>opt.Ignore())
            .ForMember(dest=>dest.Date,opt=>opt.MapFrom(_ => DateTime.UtcNow));
        CreateMap<SendMessageRequest, SendMessageResponse>()
            .ForMember(dest=>dest.Date,opt=>opt.Ignore())
            .ForMember(dest=>dest.UserName,opt=>opt.Ignore());
        CreateMap<MessageEntity, MessageDto>()
            .ForMember(dest=>dest.UserName,opt=>opt.Ignore())
            .ForMember(dest=>dest.Date,opt=>opt.MapFrom(src => src.Date.DateTimeToUnixTimeStamp()));
    }
}