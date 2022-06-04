using FamilyBudgetContext.Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudgetContext.Infrastructure.DataAccess
{
    public class FamilyBudgetDbContext : DbContext
    {
        public FamilyBudgetDbContext(DbContextOptions<FamilyBudgetDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new RoomConfiguration())
                .ApplyConfiguration(new RoomToUserConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                .ApplyConfiguration(new OperationConfiguration())
                .ApplyConfiguration(new MessageConfiguration());
        }
    }
}
