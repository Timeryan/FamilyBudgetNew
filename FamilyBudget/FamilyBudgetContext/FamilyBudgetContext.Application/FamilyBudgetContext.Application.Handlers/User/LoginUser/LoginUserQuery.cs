using FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.LoginUser
{
    public class LoginUserQuery : IRequest<LoginUserResponse>
    {
        public LoginUserRequest Request { get; set; }

        public LoginUserQuery(LoginUserRequest request)
        {
            Request = request;
        }
    }
}
