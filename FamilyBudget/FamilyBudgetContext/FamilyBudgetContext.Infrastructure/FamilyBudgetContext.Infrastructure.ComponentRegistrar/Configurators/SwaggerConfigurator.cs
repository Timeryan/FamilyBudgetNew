using FamilyBudgetContext.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Configurators
{
    public static class SwaggerConfigurator
    {
        public static void UseSwaggerPage(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FamalyBudget v1"));
        }
    }
}