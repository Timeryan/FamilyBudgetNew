using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Application.Handlers.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.AddUserToRoom
{
    public class AddUserToRoomCommandHandler : IRequestHandler<AddUserToRoomCommand, AddUserToRoomResponse>
    {
        private readonly IRoomService _roomService;

        public AddUserToRoomCommandHandler(
            IRoomService roomService)
        {
            _roomService = roomService;
        }

        public Task<AddUserToRoomResponse> Handle(AddUserToRoomCommand command, CancellationToken cancellation)
        {
            return _roomService.AddUserToRoom(command.Request, cancellation);
        }
    }
}