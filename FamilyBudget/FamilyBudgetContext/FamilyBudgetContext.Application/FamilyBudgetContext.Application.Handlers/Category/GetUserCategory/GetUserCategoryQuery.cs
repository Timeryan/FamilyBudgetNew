using FamilyBudgetContext.Contracts.Api.Contracts.Category.GetUserCategory;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Category.GetUserCategory
{
    public class GetUserCategoryQuery : IRequest<GetUserCategoryResponse>
    {
        public GetUserCategoryRequest Request { get; set; }

        public GetUserCategoryQuery(GetUserCategoryRequest request)
        {
            Request = request;
        }
    }
}
