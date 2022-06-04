using FamilyBudgetContext.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Configurations;

public class RoomToUserConfiguration : IEntityTypeConfiguration<RoomToUserEntity>
{
    public void Configure(EntityTypeBuilder<RoomToUserEntity> builder)
    {
        
    }
}