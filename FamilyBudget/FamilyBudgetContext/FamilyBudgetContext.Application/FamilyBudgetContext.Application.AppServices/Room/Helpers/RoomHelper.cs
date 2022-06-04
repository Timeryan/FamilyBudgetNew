using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FamilyBudgetContext.Contracts.Shared.Contracts.EnumExtensions;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FamilyBudgetContext.Application.AppServices.Room.Helpers;

public static class RoomHelper
{
    private const string InviteCodeTemplate = "FB-";
    private const int CodeLenght = 6;

    public static string GetInviteCode(this string roomName)
    {
        var code = new StringBuilder();
        for (var i = 0; i < CodeLenght; i++)
        {
            if (Random.Shared.Next(0, 2) == 1)
            {
                code.Append(Random.Shared.Next(0, 10));
            }
            else
            {
                code.Append((char)Random.Shared.Next(65,91));
            }
        }

        return $"{InviteCodeTemplate}{code}";
    }

    public static string GetUserColor(this RoomEntity room)
    {
        var existColor = room.RoomToUser.Select(x => (int)x.UserColor?.GetColorByCode());
        var range = Enumerable.Range(1, 14).Where(i => !existColor.Contains(i));

        var index = Random.Shared.Next(0, 14 - existColor.Count());
        var code = range.ElementAt(index);
        
        return ((UserColorEnum)Enum.ToObject(typeof(UserColorEnum), code)).GetCodeByColor();
    }
}