using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.User.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.User.UpdateUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(
            IUserService userService)
        {
            _userService = userService;
        }

        public Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellation)
        {
            return _userService.UpdateUser(request.Request, cancellation);
        }
    }
}