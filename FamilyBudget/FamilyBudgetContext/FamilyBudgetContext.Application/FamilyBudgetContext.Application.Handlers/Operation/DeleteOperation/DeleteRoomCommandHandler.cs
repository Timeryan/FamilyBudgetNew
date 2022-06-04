using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Operation.Services;
using FamilyBudgetContext.Application.Handlers.Operation.DeleteOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.DeleteOperation;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Operation.DeleteOperation
{
    public class DeleteOperationCommandHandler : IRequestHandler<DeleteOperationCommand, DeleteOperationResponse>
    {
        private readonly IOperationService _operationService;

        public DeleteOperationCommandHandler(
            IOperationService operationService)
        {
            _operationService = operationService;
        }

        public Task<DeleteOperationResponse> Handle(DeleteOperationCommand command, CancellationToken cancellation)
        {
            return _operationService.DeleteOperation(command.Request, cancellation);
        }
    }
}