using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public RegisterUserRequest Request { get; set; }

        public RegisterUserCommand(RegisterUserRequest request)
        {
            Request = request;
        }
    }
}
