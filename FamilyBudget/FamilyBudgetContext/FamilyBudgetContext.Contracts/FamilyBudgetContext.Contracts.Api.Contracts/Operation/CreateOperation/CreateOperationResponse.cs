
namespace FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;

public class CreateOperationResponse
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public long Date { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
}