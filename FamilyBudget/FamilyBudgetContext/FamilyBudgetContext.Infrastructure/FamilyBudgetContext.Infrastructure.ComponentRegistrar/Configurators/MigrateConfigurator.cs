using FamilyBudgetContext.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Configurators
{
    public static class MigrateConfigurator
    {
        public static void UseDatabaseMigrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<FamilyBudgetDbContext>();
            db.Database.Migrate();
        }
    }
}