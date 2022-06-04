using System;
using Common.DataAccess.Repositories;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Infrastructure.DataAccess;
using FamilyBudgetContext.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars;

public static class DataAccessRegistrar
{
    private const string ConnectionStringsLocal = "ConnectionStringsLocal";
    private const string ConnectionStringsDocker = "ConnectionStringsDocker";

    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment )
    {
        var connectionStringFieldName = environment.IsDevelopment()
            ? ConnectionStringsLocal
            : ConnectionStringsDocker;
        
        var connectionString = configuration.GetConnectionString(connectionStringFieldName);
        
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{connectionStringFieldName}'");
            
        services.AddDbContextPool<FamilyBudgetDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseLazyLoadingProxies();
        });

        services.AddScoped<DbContext>(sp => sp.GetRequiredService<FamilyBudgetDbContext>());
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomToUserRepository, RoomToUserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOperationRepository, OperationRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
    }
}