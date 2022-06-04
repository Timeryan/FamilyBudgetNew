using FamilyBudgetContext.Host.Public.Api.Hubs;
using FamilyBudgetContext.Infrastructure.ComponentRegistrar.Configurators;
using FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FamilyBudgetContext.Host.Public.Api
{
    /// <summary>
    /// ����� ������������ ����������.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ������������.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ����� ���������.
        /// </summary>
        public IHostEnvironment Environment { get; }

        public Startup(IHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }
        
        /// <summary>
        /// ����� ������������ �������� ����������.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiServices(Configuration);
            services.AddAuthServices(Configuration);
            services.AddDataAccessServices(Configuration, Environment);
            services.AddAutoMapperService();
            services.AddHandlerService();
            services.AddAppServices();
            services.AddRabbitMqMassTransit();
        }
        
        /// <summary>
        /// ����� ������������ ����������.
        /// </summary>
        /// <param name="app">������ ����������.</param>
        /// <param name="env">��������� ����������.</param>
        public static void Configure(IApplicationBuilder app, IHostEnvironment env)
        {

            app.UseDatabaseMigrate();
            app.UseSwaggerPage();
            app.UseDeveloperExceptionPage();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            

            app.UseExceptionHandling();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
