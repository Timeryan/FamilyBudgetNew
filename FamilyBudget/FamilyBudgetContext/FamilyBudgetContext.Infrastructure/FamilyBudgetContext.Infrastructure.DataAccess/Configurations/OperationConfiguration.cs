using FamilyBudgetContext.Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Configurations;

public class OperationConfiguration : IEntityTypeConfiguration<OperationEntity>
{
    public void Configure(EntityTypeBuilder<OperationEntity> builder)
    {
        
    }
}