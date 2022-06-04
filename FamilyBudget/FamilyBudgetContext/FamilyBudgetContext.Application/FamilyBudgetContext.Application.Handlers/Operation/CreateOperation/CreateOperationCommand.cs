using FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Operation.CreateOperation
{
    public class CreateOperationCommand : IRequest<CreateOperationResponse>
    {
        public CreateOperationRequest Request { get; set; }

        public CreateOperationCommand(CreateOperationRequest request)
        {
            Request = request;
        }
    }
}
