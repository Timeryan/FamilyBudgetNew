using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.CreateDefaultCategories;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.GetUserCategory;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.DeleteUserFromRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;

namespace FamilyBudgetContext.Application.AppServices.Category.Services;

public interface ICategoryService
{
    Task<GetUserCategoryResponse> GetUserCategory(GetUserCategoryRequest requestRequest, CancellationToken cancellation);
    Task<CreateDefaultCategoriesResponse> CreateDefaultCategories(CreateDefaultCategoriesRequest request, CancellationToken cancellation);
}