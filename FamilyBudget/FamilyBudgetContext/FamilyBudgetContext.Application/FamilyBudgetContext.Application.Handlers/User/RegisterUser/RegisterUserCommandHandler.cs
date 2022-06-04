using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(
            IUserService userService)
        {
            _userService = userService;
        }

        public Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellation)
        {
            return _userService.RegisterUser(request.Request, cancellation);
        }
    }
}