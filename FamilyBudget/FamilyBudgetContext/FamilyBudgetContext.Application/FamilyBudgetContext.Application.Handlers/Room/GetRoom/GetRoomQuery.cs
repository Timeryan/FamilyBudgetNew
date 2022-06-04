using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.GetRoom
{
    public class GetRoomQuery : IRequest<GetRoomResponse>
    {
        public GetRoomRequest Request { get; set; }

        public GetRoomQuery(GetRoomRequest request)
        {
            Request = request;
        }
    }
}
