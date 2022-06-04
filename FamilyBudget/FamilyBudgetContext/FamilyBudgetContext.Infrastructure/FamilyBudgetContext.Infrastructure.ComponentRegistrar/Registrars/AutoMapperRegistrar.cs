using AutoMapper;
using FamilyBudgetContext.Application.AppServices.Shared.MapProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars
{
    public static class AutoMapperRegistrar
    {
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(config =>
                {
                    config.AddProfile(new UserMapProfile());
                    config.AddProfile(new RoomMapProfile());
                    config.AddProfile(new CategoryMapProfile());
                    config.AddProfile(new OperationMapProfile());
                    config.AddProfile(new ChatMapProfile());
                }
            );
            configuration.AssertConfigurationIsValid();
                
            return configuration;
            
        }
    }
}