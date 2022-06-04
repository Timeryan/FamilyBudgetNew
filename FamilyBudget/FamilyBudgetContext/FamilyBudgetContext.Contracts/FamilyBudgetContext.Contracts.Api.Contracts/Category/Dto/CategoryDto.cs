using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Category.Dto;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string IconCode { get; set; }
    public string IconColor { get; set; }
    public int BlockLocation { get; set; }
    public int PositionLocation { get; set; }
    public MoneyFlowTypeEnum MoneyFlowType { get; set; }
}