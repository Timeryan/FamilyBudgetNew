using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars
{
    public static class MasstransitRegistrar
    {
        public static void AddRabbitMqMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });
        }
    }
}
