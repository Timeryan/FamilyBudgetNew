using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<RoomEntity>
{
    public void Configure(EntityTypeBuilder<RoomEntity> builder)
    {
        builder
            .HasMany(p => p.Users)
            .WithMany(p => p.Rooms)
            .UsingEntity<RoomToUserEntity>(
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.RoomToUser)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Room)
                    .WithMany(p => p.RoomToUser)
                    .HasForeignKey(pt => pt.RoomId),
                j =>
                {
                    j.Property(pt => pt.Role).HasDefaultValue(UserRoleInRoomEnum.Member);
                    j.HasIndex(t => new { t.RoomId, t.UserId }).IsUnique();
                });
    }
}