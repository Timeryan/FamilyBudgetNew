using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.DeleteUserFromRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.UpdateRoom;

namespace FamilyBudgetContext.Application.AppServices.Room.Services;

public interface IRoomService
{
    Task<CreateRoomResponse> CreateRoom(CreateRoomRequest request, CancellationToken cancellation);
    Task<GetRoomByInviteCodeResponse> GetRoomByInviteCode(GetRoomByInviteCodeRequest request, CancellationToken cancellation);
    Task<AddUserToRoomResponse> AddUserToRoom(AddUserToRoomRequest request, CancellationToken cancellation);
    Task<GetRoomResponse> GetRoom(GetRoomRequest requestRequest, CancellationToken cancellation);
    Task<DeleteUserFromRoomResponse> DeleteUserFromRoom(DeleteUserFromRoomRequest commandRequest, CancellationToken cancellation);
    Task<UpdateRoomResponse> UpdateRoom(UpdateRoomRequest commandRequest, CancellationToken cancellation);
}