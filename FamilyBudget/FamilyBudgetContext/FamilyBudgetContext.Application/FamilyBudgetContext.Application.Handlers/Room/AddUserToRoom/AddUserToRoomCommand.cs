using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.AddUserToRoom
{
    public class AddUserToRoomCommand : IRequest<AddUserToRoomResponse>
    {
        public AddUserToRoomRequest Request { get; set; }

        public AddUserToRoomCommand(AddUserToRoomRequest request)
        {
            Request = request;
        }
    }
}
