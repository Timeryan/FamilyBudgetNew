namespace FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;

public class CreateOperationRequest
{
    public int CategoryId { get; set; }
    public long Date { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
}