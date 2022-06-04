using FamilyBudgetContext.Contracts.Api.Contracts.Room.UpdateRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.UpdateRoom
{
    public class UpdateRoomCommand : IRequest<UpdateRoomResponse>
    {
        public UpdateRoomRequest Request { get; set; }

        public UpdateRoomCommand(UpdateRoomRequest request)
        {
            Request = request;
        }
    }
}
