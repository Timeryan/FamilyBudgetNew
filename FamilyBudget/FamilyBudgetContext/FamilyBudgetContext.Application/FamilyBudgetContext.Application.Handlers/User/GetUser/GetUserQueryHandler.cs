using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
		private readonly IUserService _userService;

		public GetUserQueryHandler(
			IUserService userService)
		{
			_userService = userService;
		}
		
		public Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellation)
		{
			return _userService.GetUser(request.Request, cancellation);
		}
    }
}
