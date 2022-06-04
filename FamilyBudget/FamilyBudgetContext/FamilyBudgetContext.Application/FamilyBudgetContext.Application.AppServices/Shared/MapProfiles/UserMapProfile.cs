using AutoMapper;
using FamilyBudgetContext.Application.AppServices.User.Helpers;
using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.MapProfiles;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<UserEntity, LoginUserResponse>()
            .ForMember(dest=>dest.Token,opt=>opt.Ignore())
            .ForMember(dest=>dest.RoomId,opt=>opt.Ignore());

        CreateMap<RegisterUserRequest, UserEntity>()
            .ForMember(dest=>dest.IsEmailConfirm,opt=>opt.Ignore())
            .ForMember(dest=>dest.ConfirmCode,opt=>opt.Ignore())
            .ForMember(dest=>dest.Id,opt=>opt.Ignore())
            .ForMember(dest=>dest.ModifyDate,opt=>opt.Ignore())
            .ForMember(dest=>dest.IsEmailConfirm,opt=>opt.Ignore())
            .ForMember(dest=>dest.Rooms,opt=>opt.Ignore())
            .ForMember(dest=>dest.RoomToUser,opt=>opt.Ignore())
            .ForMember(dest=>dest.Categories,opt=>opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password.CreatePasswordHash()));
        
        CreateMap<UserEntity, RegisterUserResponse>();
        CreateMap<UserEntity, GetUserResponse>();
    }
}