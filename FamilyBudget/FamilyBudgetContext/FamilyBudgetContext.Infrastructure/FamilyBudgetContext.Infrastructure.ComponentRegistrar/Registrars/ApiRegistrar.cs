using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars
{
    public static class ApiRegistrar
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwagger();
            services.AddSignalR();
        }
    }
}
