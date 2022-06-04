using System.Collections.Generic;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.Dto;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Operation.GetCategoryOperation;

public class GetCategoryOperationResponse
{
    public IList<OperationDto> Operations { get; set; }
}