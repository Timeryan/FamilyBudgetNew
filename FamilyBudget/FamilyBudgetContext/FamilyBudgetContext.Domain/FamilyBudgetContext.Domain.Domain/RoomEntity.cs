using System.Collections.Generic;
using Common.Domain;
using Common.Domain.Domain;

namespace FamilyBudgetContext.Domain.Domain
{
    public class RoomEntity : Entity
    {
        public string? Name { get; set; }
        public string? Photo { get; set; }
        public string? InviteCode { get; set; }
        public virtual IList<UserEntity> Users { get; set; } = new List<UserEntity>();
        public virtual IList<RoomToUserEntity> RoomToUser { get; set; } = new List<RoomToUserEntity>();
    }
}