using Common.Infrastucture.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Configurators
{
    public static class ExceptionHandlingConfigurator
    {
        public static void UseExceptionHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}