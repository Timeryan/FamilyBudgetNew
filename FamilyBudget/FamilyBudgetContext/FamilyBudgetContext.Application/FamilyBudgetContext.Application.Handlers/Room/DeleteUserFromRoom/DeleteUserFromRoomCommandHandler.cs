using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Application.Handlers.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.DeleteUserFromRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.DeleteUserFromRoom
{
    public class DeleteUserFromRoomCommandHandler : IRequestHandler<DeleteUserFromRoomCommand, DeleteUserFromRoomResponse>
    {
        private readonly IRoomService _roomService;

        public DeleteUserFromRoomCommandHandler(
            IRoomService roomService)
        {
            _roomService = roomService;
        }

        public Task<DeleteUserFromRoomResponse> Handle(DeleteUserFromRoomCommand command, CancellationToken cancellation)
        {
            return _roomService.DeleteUserFromRoom(command.Request, cancellation);
        }
    }
}