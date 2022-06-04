using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FamilyBudgetContext.Infrastructure.ComponentRegistrar.Registrars;

public static class AuthRegistrar
{
    private const string AuthOption = "AuthOption";
    private const string Issuer = "Issuer";
    private const string Audience = "Audience";
    private const string SecretKey = "SecretKey";

    public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection(AuthOption);
        
        if (authOptions == null)
            throw new InvalidOperationException(
                $"Не найдена строка с настройками авторизации: '{AuthOption}'");
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = authOptions.GetSection(Issuer).Value,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience =  authOptions.GetSection(Audience).Value,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.GetSection(SecretKey).Value)),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true
                };
            });
    }
}