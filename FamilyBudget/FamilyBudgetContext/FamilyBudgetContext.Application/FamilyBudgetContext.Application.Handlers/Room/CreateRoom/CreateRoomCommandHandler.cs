using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Application.Handlers.User.RegisterUser;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, CreateRoomResponse>
    {
        private readonly IRoomService _roomService;

        public CreateRoomCommandHandler(
            IRoomService roomService)
        {
            _roomService = roomService;
        }

        public Task<CreateRoomResponse> Handle(CreateRoomCommand command, CancellationToken cancellation)
        {
            return _roomService.CreateRoom(command.Request, cancellation);
        }
    }
}