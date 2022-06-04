using FamilyBudgetContext.Contracts.Api.Contracts.Operation.GetCategoryOperation;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Operation.GetCategoryOperation
{
    public class GetCategoryOperationQuery : IRequest<GetCategoryOperationResponse>
    {
        public GetCategoryOperationRequest Request { get; set; }

        public GetCategoryOperationQuery(GetCategoryOperationRequest request)
        {
            Request = request;
        }
    }
}
