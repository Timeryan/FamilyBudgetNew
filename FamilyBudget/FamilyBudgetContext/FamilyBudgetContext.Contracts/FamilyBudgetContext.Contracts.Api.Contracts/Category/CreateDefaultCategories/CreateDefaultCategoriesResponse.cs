using System.Collections.Generic;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Category.CreateDefaultCategories;

public class CreateDefaultCategoriesResponse
{
   public List<CategoryEntity> DefaultCategories { get; set; }
}