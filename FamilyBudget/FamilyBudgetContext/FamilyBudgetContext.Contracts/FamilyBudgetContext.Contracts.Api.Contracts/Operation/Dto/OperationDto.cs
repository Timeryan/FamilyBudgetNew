namespace FamilyBudgetContext.Contracts.Api.Contracts.Operation.Dto;

public class OperationDto
{
    public int Id { get; set; }
    public long Date { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
}