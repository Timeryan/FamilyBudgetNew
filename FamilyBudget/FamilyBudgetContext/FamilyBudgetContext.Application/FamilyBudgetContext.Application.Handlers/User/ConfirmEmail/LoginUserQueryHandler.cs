using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.User.ConfirmEmail;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ConfirmEmailResponse>
    {
		private readonly IUserService _userService;

		public ConfirmEmailCommandHandler(
			IUserService userService)
		{
			_userService = userService;
		}

		public Task<ConfirmEmailResponse> Handle(ConfirmEmailCommand request, CancellationToken cancellation)
		{
			return _userService.ConfirmEmail(request.Request, cancellation);
		}
    }
}
