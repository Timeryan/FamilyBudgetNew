using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.GetRoomByInviteCode
{
    public class GetRoomByInviteCodeQueryHandler : IRequestHandler<GetRoomByInviteCodeQuery, GetRoomByInviteCodeResponse>
    {
		private readonly IRoomService _roomService;

		public GetRoomByInviteCodeQueryHandler(IRoomService roomService)
		{
			_roomService = roomService;
		}

		public Task<GetRoomByInviteCodeResponse> Handle(GetRoomByInviteCodeQuery request, CancellationToken cancellation)
		{
			return _roomService.GetRoomByInviteCode(request.Request, cancellation);
		}
    }
}
