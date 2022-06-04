using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FamilyBudgetContext.Application.AppServices.User.Helpers;

public static class UserHelper
{
    private const string AuthOption = "AuthOption";
    private const string Issuer = "Issuer";
    private const string Audience = "Audience";
    private const string SecretKey = "SecretKey";

    private const string ConfirmCodeTemplate = "FB-";

    public static string CreatePasswordHash(this string password)
    {
       var md5 = MD5.Create();

       var b = Encoding.UTF8.GetBytes(password);
       var hash = md5.ComputeHash(b);

       var sb = new StringBuilder();
       foreach (var h in hash)
           sb.Append(h.ToString("X2"));

       return sb.ToString();
    }

    public static string CreateJwtToken(this UserEntity user, IConfiguration configuration)
    {
        var authOptions = configuration.GetSection(AuthOption);
        
        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name)
        };
        
        var jwt = new JwtSecurityToken(
            issuer: authOptions.GetSection(Issuer).Value,
            audience: authOptions.GetSection(Audience).Value,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(365)), // время действия 2 минуты
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.GetSection(SecretKey).Value)), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public static string GetConfirmCode()
    {
        return ConfirmCodeTemplate + Random.Shared.Next(0, 9999).ToString("D4");
    }
}