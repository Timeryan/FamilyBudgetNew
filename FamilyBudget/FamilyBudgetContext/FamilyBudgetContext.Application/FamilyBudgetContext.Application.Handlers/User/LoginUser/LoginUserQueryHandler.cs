using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
    {
		private readonly IUserService _userService;

		public LoginUserQueryHandler(
			IUserService userService)
		{
			_userService = userService;
		}

		public Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellation)
		{
			return _userService.LoginUser(request.Request, cancellation);
		}
    }
}
