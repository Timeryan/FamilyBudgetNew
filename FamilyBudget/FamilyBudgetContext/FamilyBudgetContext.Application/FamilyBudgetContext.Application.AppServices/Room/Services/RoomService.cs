using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Infrastucture.Infrastructure.Exception;
using FamilyBudgetContext.Application.AppServices.Room.Helpers;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.DeleteUserFromRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.UpdateRoom;
using FamilyBudgetContext.Contracts.Shared.Contracts.EnumExtensions;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;
using Microsoft.AspNetCore.Http;
using SystemException = Common.Infrastucture.Infrastructure.Exception.SystemException;

namespace FamilyBudgetContext.Application.AppServices.Room.Services;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomToUserRepository _roomToUserRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContext;

    public RoomService(IRoomRepository roomRepository, IMapper mapper, IHttpContextAccessor httpContext, IUserRepository userRepository, IRoomToUserRepository roomToUserRepository)
    {
        _roomRepository = roomRepository;
        _mapper = mapper;
        _httpContext = httpContext;
        _userRepository = userRepository;
        _roomToUserRepository = roomToUserRepository;
    }

    public async Task<CreateRoomResponse> CreateRoom(CreateRoomRequest request, CancellationToken cancellation)
    {
        var userId = Convert.ToInt32( _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var user = await _userRepository.GetByIdAsync(userId, cancellation);
        if (user.Rooms.Count == 1)
        {
            throw new WrongDataException("Пользователь уже состоит в комнате");
        }
        
        var room = _mapper.Map<RoomEntity>(request);
        room.InviteCode = room.Name.GetInviteCode();
        
        var roomId = await _roomRepository.AddAsync(room, cancellation);

        await _roomToUserRepository.AddUserToRoomAsync(
            roomId,
            userId,
            UserRoleInRoomEnum.Owner,
            UserColorEnum.Blue.GetCodeByColor(),
            cancellation);
        var roomEntity = await _roomRepository.GetByIdAsync(roomId, cancellation);
        
        var createRoomResponse = _mapper.Map<CreateRoomResponse>(roomEntity);
        createRoomResponse.Users.FirstOrDefault(u => u.Id == userId)!.Role = UserRoleInRoomEnum.Owner;
        foreach (var userDto in createRoomResponse.Users)
        {
            userDto.UserColor = roomEntity.RoomToUser.FirstOrDefault(x => x.UserId == userDto.Id)?.UserColor;
        }
        
        return createRoomResponse;
    }

    public Task<GetRoomByInviteCodeResponse> GetRoomByInviteCode(GetRoomByInviteCodeRequest request, CancellationToken cancellation)
    {
        var roomEntity = _roomRepository.Where(r => r.InviteCode == request.InviteCode).FirstOrDefault();
        if (roomEntity == null)
        {
            throw new WrongDataException("Комнаты с таким кодом не существует");
        }
        
        var createRoomResponse = _mapper.Map<GetRoomByInviteCodeResponse>(roomEntity);
        foreach (var userDto in createRoomResponse.Users)
        {
            var roomToUser = roomEntity.RoomToUser.FirstOrDefault(x => x.UserId == userDto.Id);
            if (roomToUser == null)
            {
                throw new NullReferenceException(nameof(roomToUser));
            }
            userDto.Role = roomToUser.Role;
            userDto.UserColor = roomToUser.UserColor;
        }

        return Task.FromResult(createRoomResponse);
    }

    public async Task<AddUserToRoomResponse> AddUserToRoom(AddUserToRoomRequest request, CancellationToken cancellation)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId, cancellation);
        
        await _roomToUserRepository.AddUserToRoomAsync(
            request.RoomId, 
            request.UserId, 
            UserRoleInRoomEnum.Member,
            room.GetUserColor(),
            cancellation);
        return new AddUserToRoomResponse
        {
            IsSuccess = true
        };
    }

    public async Task<GetRoomResponse> GetRoom(GetRoomRequest request, CancellationToken cancellation)
    {
        var roomEntity = await _roomRepository.GetByIdAsync(request.Id, cancellation);
        if (roomEntity == null)
        {
            throw new WrongDataException("Комнаты с таким индитификатором не существует");
        }
        
        var createRoomResponse = _mapper.Map<GetRoomResponse>(roomEntity);
        foreach (var userDto in createRoomResponse.Users)
        {
            var roomToUser = roomEntity.RoomToUser.FirstOrDefault(x => x.UserId == userDto.Id);
            
            if (roomToUser == null)
            {
                throw new NullReferenceException(nameof(roomToUser));
            }
            
            userDto.Role = roomToUser.Role;
            userDto.UserColor = roomToUser.UserColor;
        }

        return createRoomResponse;
    }

    public async Task<DeleteUserFromRoomResponse> DeleteUserFromRoom(DeleteUserFromRoomRequest request, CancellationToken cancellation)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId, cancellation);
        var userToRoom = room.RoomToUser.FirstOrDefault(x => x.UserId == request.UserId);

        if (userToRoom == null)
        {
            throw new WrongDataException("Комната не содержит, данного пользователя");
        }

        if (userToRoom.Role == UserRoleInRoomEnum.Owner)
        {
            var newOwnerToRoom = room.RoomToUser.FirstOrDefault(x => x.UserId != request.UserId);

            if (newOwnerToRoom == null)
            { 
                await _roomRepository.DeleteAsync(request.RoomId, cancellation);
                return new DeleteUserFromRoomResponse
                {
                    IsSuccess = true
                };
            }

            await _roomToUserRepository.UpdateUserRoleInRoomAsync(request.RoomId, newOwnerToRoom.UserId,
                UserRoleInRoomEnum.Owner, cancellation);
        }

        await _roomToUserRepository.DeleteUserFromRoomAsync(request.RoomId, request.UserId, cancellation);
        return new DeleteUserFromRoomResponse
        {
            IsSuccess = true
        };
    }

    public async Task<UpdateRoomResponse> UpdateRoom(UpdateRoomRequest request, CancellationToken cancellation)
    {
        var room = await _roomRepository.GetByIdAsync(request.Id, cancellation);

        room.Name = request.Name ?? room.Name;
        room.Photo = request.Photo ?? room.Photo;
            
        await _roomRepository.UpdateAsync(room, cancellation);

        return new UpdateRoomResponse
        {
            Id = room.Id
        };
    }
}