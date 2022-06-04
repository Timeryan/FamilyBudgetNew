using FamilyBudgetContext.Contracts.Api.Contracts.User.PasswordRecovery;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.User.PasswordRecovery
{
    public class PasswordRecoveryCommand : IRequest<PasswordRecoveryResponse>
    {
        public PasswordRecoveryRequest Request { get; set; }

        public PasswordRecoveryCommand(PasswordRecoveryRequest request)
        {
            Request = request;
        }
    }
}
