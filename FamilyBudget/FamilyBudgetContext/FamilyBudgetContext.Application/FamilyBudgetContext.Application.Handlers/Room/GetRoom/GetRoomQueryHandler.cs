using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Application.Handlers.User.GetUser;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Room.GetRoom
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, GetRoomResponse>
    {
		private readonly IRoomService _roomService;

		public GetRoomQueryHandler(
			IRoomService roomService)
		{
			_roomService = roomService;
		}
		
		public Task<GetRoomResponse> Handle(GetRoomQuery request, CancellationToken cancellation)
		{
			return _roomService.GetRoom(request.Request, cancellation);
		}
    }
}
