using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.User.PasswordRecovery;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.PasswordRecovery
{
    public class PasswordRecoveryCommandHandler : IRequestHandler<PasswordRecoveryCommand, PasswordRecoveryResponse>
    {
        private readonly IUserService _userService;

        public PasswordRecoveryCommandHandler(
            IUserService userService)
        {
            _userService = userService;
        }

        public Task<PasswordRecoveryResponse> Handle(PasswordRecoveryCommand request, CancellationToken cancellation)
        {
            return _userService.PasswordRecovery(request.Request, cancellation);
        }
    }
}