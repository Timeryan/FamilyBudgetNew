using FamilyBudgetContext.Contracts.Api.Contracts.User.ConfirmEmail;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<ConfirmEmailResponse>
    {
        public ConfirmEmailRequest Request { get; set; }

        public ConfirmEmailCommand(ConfirmEmailRequest request)
        {
            Request = request;
        }
    }
}
