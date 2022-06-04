using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Operation.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Operation.CreateOperation
{
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, CreateOperationResponse>
    {
        private readonly IOperationService _operationService;

        public CreateOperationCommandHandler(
            IOperationService operationService)
        {
            _operationService = operationService;
        }

        public Task<CreateOperationResponse> Handle(CreateOperationCommand command, CancellationToken cancellation)
        {
            return _operationService.CreateOperation(command.Request, cancellation);
        }
    }
}