using System;
using Common.Domain.Domain;

namespace FamilyBudgetContext.Domain.Domain;

public class MessageEntity : Entity
{
    public int RoomId { get; set; }
    public virtual RoomEntity? Room { get; set; }
    public int UserId { get; set; }
    public virtual UserEntity? User { get; set; }
    public string? Text { get; set; }
    public DateTime Date { get; set; }
}