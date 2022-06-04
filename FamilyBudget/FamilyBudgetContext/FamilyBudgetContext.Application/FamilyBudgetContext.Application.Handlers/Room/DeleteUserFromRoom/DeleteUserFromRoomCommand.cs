using FamilyBudgetContext.Contracts.Api.Contracts.Room.DeleteUserFromRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.DeleteUserFromRoom
{
    public class DeleteUserFromRoomCommand : IRequest<DeleteUserFromRoomResponse>
    {
        public DeleteUserFromRoomRequest Request { get; set; }

        public DeleteUserFromRoomCommand(DeleteUserFromRoomRequest request)
        {
            Request = request;
        }
    }
}
