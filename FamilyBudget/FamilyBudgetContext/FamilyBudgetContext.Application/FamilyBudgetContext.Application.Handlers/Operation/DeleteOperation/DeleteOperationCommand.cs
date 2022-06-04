using FamilyBudgetContext.Contracts.Api.Contracts.Operation.DeleteOperation;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Operation.DeleteOperation
{
    public class DeleteOperationCommand : IRequest<DeleteOperationResponse>
    {
        public DeleteOperationRequest Request { get; set; }

        public DeleteOperationCommand(DeleteOperationRequest request)
        {
            Request = request;
        }
    }
}
