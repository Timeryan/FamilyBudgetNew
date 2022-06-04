using AutoMapper;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.Dto;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.MapProfiles;

public class RoomMapProfile : Profile
{
    public RoomMapProfile()
    {
        CreateMap<CreateRoomRequest, RoomEntity>()
            .ForMember(dest=>dest.Id,opt=>opt.Ignore())
            .ForMember(dest=>dest.InviteCode,opt=>opt.Ignore())
            .ForMember(dest=>dest.RoomToUser,opt=>opt.Ignore())
            .ForMember(dest=>dest.Users,opt=>opt.Ignore())
            .ForMember(dest=>dest.ModifyDate,opt=>opt.Ignore());
        CreateMap<RoomEntity, CreateRoomResponse>();
        CreateMap<UserEntity, UserDto>()
            .ForMember(dest=>dest.UserColor,opt=>opt.Ignore())
            .ForMember(dest=>dest.Role,opt=> opt.MapFrom(_ => UserRoleInRoomEnum.Member));
        
        CreateMap<RoomEntity, GetRoomByInviteCodeResponse>();
        
        CreateMap<RoomEntity, GetRoomResponse>();
    }
}