using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Application.Handlers.Room.UpdateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.UpdateRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, UpdateRoomResponse>
    {
        private readonly IRoomService _roomService;

        public UpdateRoomCommandHandler(
            IRoomService roomService)
        {
            _roomService = roomService;
        }

        public Task<UpdateRoomResponse> Handle(UpdateRoomCommand command, CancellationToken cancellation)
        {
            return _roomService.UpdateRoom(command.Request, cancellation);
        }
    }
}