using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.DeleteOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.GetCategoryOperation;

namespace FamilyBudgetContext.Application.AppServices.Operation.Services;

public interface IOperationService
{
    Task<CreateOperationResponse> CreateOperation(CreateOperationRequest request, CancellationToken cancellation);
    Task<DeleteOperationResponse> DeleteOperation(DeleteOperationRequest commandRequest, CancellationToken cancellation);
    Task<GetCategoryOperationResponse> GetCategoryOperation(GetCategoryOperationRequest requestRequest, CancellationToken cancellation);
}