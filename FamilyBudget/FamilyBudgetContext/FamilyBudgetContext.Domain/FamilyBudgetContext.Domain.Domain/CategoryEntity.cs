using System.Collections.Generic;
using Common.Domain.Domain;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;

namespace FamilyBudgetContext.Domain.Domain;

public class CategoryEntity : Entity
{
    public string? Name { get; set; }
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
    public string? IconCode { get; set; }
    public string? IconColor { get; set; }
    public int BlockLocation { get; set; }
    public int PositionLocation { get; set; }
    public MoneyFlowTypeEnum MoneyFlowType { get; set; }
    public virtual IList<OperationEntity>? Operations { get; set; }
}