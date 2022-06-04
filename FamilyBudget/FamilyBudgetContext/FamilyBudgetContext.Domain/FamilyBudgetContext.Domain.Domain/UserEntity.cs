using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.Domain;
using Common.Domain.Domain;

namespace FamilyBudgetContext.Domain.Domain
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class UserEntity : Entity
    {
        [Required, StringLength(200)]
        public string? Name { get; set; }

        [Required, StringLength(200), EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? PasswordHash { get; set; }
        public string? Photo { get; set; }
        public string? ConfirmCode { get; set; }
        public bool IsEmailConfirm { get; set; }

        public virtual IList<RoomEntity>? Rooms { get; set; }
        public virtual IList<RoomToUserEntity>? RoomToUser { get; set; }
        public virtual IList<CategoryEntity>? Categories { get; set; }

    }
}
