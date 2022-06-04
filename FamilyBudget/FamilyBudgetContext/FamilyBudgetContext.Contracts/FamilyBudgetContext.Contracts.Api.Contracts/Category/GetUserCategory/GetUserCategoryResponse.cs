using System.Collections.Generic;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.Dto;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Category.GetUserCategory;

public class GetUserCategoryResponse
{
    public IList<CategoryDto> Categories { get; set; }
}