using FamilyBudgetContext.Application.Handlers.Category.GetUserCategory;
using FamilyBudgetContext.Application.Handlers.Chat.JoinChat;
using FamilyBudgetContext.Application.Handlers.Chat.SendMessage;
using FamilyBudgetContext.Application.Handlers.Operation.CreateOperation;
using FamilyBudgetContext.Application.Handlers.Operation.DeleteOperation;
using FamilyBudgetContext.Application.Handlers.Operation.GetCategoryOperation;
using FamilyBudgetContext.Application.Handlers.Room.AddUserToRoom;
using FamilyBudgetContext.Application.Handlers.Room.CreateRoom;
using FamilyBudgetContext.Application.Handlers.Room.DeleteUserFromRoom;
using FamilyBudgetContext.Application.Handlers.Room.GetRoom;
using FamilyBudgetContext.Application.Handlers.Room.GetRoomByInviteCode;
using FamilyBudgetContext.Application.Handlers.Room.UpdateRoom;
using FamilyBudgetContext.Application.Handlers.User.ConfirmEmail;
using FamilyBudgetContext.Application.Handlers.User.GetUser;
using FamilyBudgetContext.Application.Handlers.User.LoginUser;
using FamilyBudgetContext.Application.Handlers.User.PasswordRecovery;
using FamilyBudgetContext.Application.Handlers.User.RegisterUser;
using FamilyBudgetContext.Application.Handlers.User.UpdateUser;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.GetUserCategory;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.JoinChat;
using FamilyBudgetContext.Contracts.Api.Contracts.Message.SendMessage;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.DeleteOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.GetCategoryOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.DeleteUserFromRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.UpdateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.User.ConfirmEmail;
using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.PasswordRecovery;
using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.UpdateUser;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars
{
    public static class HandlerRegistrar
    {
        public static IServiceCollection AddHandlerService(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApiRegistrar));
            
            services.AddTransient<IRequestHandler<GetUserQuery, GetUserResponse>, GetUserQueryHandler>();
            services.AddTransient<IRequestHandler<LoginUserQuery, LoginUserResponse>, LoginUserQueryHandler>();
            services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserResponse>, RegisterUserCommandHandler>();
            services.AddTransient<IRequestHandler<ConfirmEmailCommand, ConfirmEmailResponse>, ConfirmEmailCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateUserCommand, UpdateUserResponse>, UpdateUserCommandHandler>();
            services.AddTransient<IRequestHandler<PasswordRecoveryCommand, PasswordRecoveryResponse>, PasswordRecoveryCommandHandler>();
            
            services.AddTransient<IRequestHandler<CreateRoomCommand, CreateRoomResponse>, CreateRoomCommandHandler>();
            services.AddTransient<IRequestHandler<GetRoomByInviteCodeQuery, GetRoomByInviteCodeResponse>, GetRoomByInviteCodeQueryHandler>();
            services.AddTransient<IRequestHandler<AddUserToRoomCommand, AddUserToRoomResponse>, AddUserToRoomCommandHandler>();
            services.AddTransient<IRequestHandler<GetRoomQuery, GetRoomResponse>, GetRoomQueryHandler>();
            services.AddTransient<IRequestHandler<DeleteUserFromRoomCommand, DeleteUserFromRoomResponse>, DeleteUserFromRoomCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateRoomCommand, UpdateRoomResponse>, UpdateRoomCommandHandler>();
            
            services.AddTransient<IRequestHandler<GetUserCategoryQuery, GetUserCategoryResponse>, GetUserCategoryQueryHandler>();
            
            services.AddTransient<IRequestHandler<CreateOperationCommand, CreateOperationResponse>, CreateOperationCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteOperationCommand, DeleteOperationResponse>, DeleteOperationCommandHandler>();
            services.AddTransient<IRequestHandler<GetCategoryOperationQuery, GetCategoryOperationResponse>, GetCategoryOperationQueryHandler>();
            
            services.AddTransient<IRequestHandler<JoinChatQuery, JoinChatResponse>, JoinChatQueryHandler>();
            services.AddTransient<IRequestHandler<SendMessageCommand, SendMessageResponse>, SendMessageCommandHandler>();
            
            return services;
        }
    }
}