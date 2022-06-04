using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Operation.Services;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.GetCategoryOperation;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Operation.GetCategoryOperation
{
    public class GetCategoryOperationQueryHandler : IRequestHandler<GetCategoryOperationQuery, GetCategoryOperationResponse>
    {
		private readonly IOperationService _operationService;

		public GetCategoryOperationQueryHandler(
			IOperationService operationService)
		{
			_operationService = operationService;
		}
		
		public Task<GetCategoryOperationResponse> Handle(GetCategoryOperationQuery request, CancellationToken cancellation)
		{
			return _operationService.GetCategoryOperation(request.Request, cancellation);
		}
    }
}
