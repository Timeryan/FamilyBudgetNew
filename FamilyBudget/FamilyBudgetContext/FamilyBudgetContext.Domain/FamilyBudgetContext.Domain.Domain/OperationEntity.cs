using System;
using Common.Domain.Domain;

namespace FamilyBudgetContext.Domain.Domain;

public class OperationEntity : Entity
{
    public int CategoryId { get; set; }
    public virtual CategoryEntity? Category { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
}