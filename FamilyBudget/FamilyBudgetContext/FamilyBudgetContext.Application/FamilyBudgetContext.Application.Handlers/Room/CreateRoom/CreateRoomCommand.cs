using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.CreateRoom
{
    public class CreateRoomCommand : IRequest<CreateRoomResponse>
    {
        public CreateRoomRequest Request { get; set; }

        public CreateRoomCommand(CreateRoomRequest request)
        {
            Request = request;
        }
    }
}
