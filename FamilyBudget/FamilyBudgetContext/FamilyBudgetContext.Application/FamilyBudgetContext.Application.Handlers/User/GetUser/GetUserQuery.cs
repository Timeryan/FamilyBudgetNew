using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.GetUser
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public GetUserRequest Request { get; set; }

        public GetUserQuery(GetUserRequest request)
        {
            Request = request;
        }
    }
}
