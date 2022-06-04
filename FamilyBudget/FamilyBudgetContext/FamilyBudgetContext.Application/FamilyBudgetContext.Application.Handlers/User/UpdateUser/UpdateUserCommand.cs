using FamilyBudgetContext.Contracts.Api.Contracts.User.UpdateUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public UpdateUserRequest Request { get; set; }

        public UpdateUserCommand(UpdateUserRequest request)
        {
            Request = request;
        }
    }
}
