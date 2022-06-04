using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.AppServices.Category.Services;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Application.Handlers.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.GetUserCategory;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using MediatR;

namespace FamilyBudgetContext.Application.Handlers.Category.GetUserCategory
{
    public class GetUserCategoryQueryHandler : IRequestHandler<GetUserCategoryQuery, GetUserCategoryResponse>
    {
		private readonly ICategoryService _categoryService;

		public GetUserCategoryQueryHandler(
			ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		
		public Task<GetUserCategoryResponse> Handle(GetUserCategoryQuery request, CancellationToken cancellation)
		{
			return _categoryService.GetUserCategory(request.Request, cancellation);
		}
    }
}
