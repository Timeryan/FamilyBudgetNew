using Common.Application.AppServices.Publishers;
using FamilyBudgetContext.Application.AppServices.Category.Services;
using FamilyBudgetContext.Application.AppServices.Chat.Service;
using FamilyBudgetContext.Application.AppServices.Operation.Services;
using FamilyBudgetContext.Application.AppServices.Room.Services;
using FamilyBudgetContext.Application.AppServices.User.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars;

public static class AppServicesRegistrar
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailPublisher, EmailPublisher>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOperationService, OperationService>();
        services.AddScoped<IChatService, ChatService>();
            
        return services;
    }
}