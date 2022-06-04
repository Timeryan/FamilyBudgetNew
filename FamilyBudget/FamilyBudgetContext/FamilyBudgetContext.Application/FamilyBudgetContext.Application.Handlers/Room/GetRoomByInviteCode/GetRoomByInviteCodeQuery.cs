using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.GetRoomByInviteCode
{
    public class GetRoomByInviteCodeQuery : IRequest<GetRoomByInviteCodeResponse>
    {
        public GetRoomByInviteCodeRequest Request { get; set; }

        public GetRoomByInviteCodeQuery(GetRoomByInviteCodeRequest request)
        {
            Request = request;
        }
    }
}
