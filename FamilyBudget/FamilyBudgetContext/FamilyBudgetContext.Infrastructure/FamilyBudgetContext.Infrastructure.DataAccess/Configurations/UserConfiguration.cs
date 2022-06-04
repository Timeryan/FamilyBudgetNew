using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasMany(p => p.Rooms)
                .WithMany(p => p.Users)
                .UsingEntity<RoomToUserEntity>(
                    j => j
                        .HasOne(pt => pt.Room)
                        .WithMany(t => t.RoomToUser)
                        .HasForeignKey(pt => pt.RoomId),
                    j => j
                        .HasOne(pt => pt.User)
                        .WithMany(p => p.RoomToUser)
                        .HasForeignKey(pt => pt.UserId),
                    j =>
                    {
                        j.Property(pt => pt.Role).HasDefaultValue(UserRoleInRoomEnum.Member);
                        j.HasIndex(t => new { t.RoomId, t.UserId }).IsUnique();
                    });
        }
    }
}
